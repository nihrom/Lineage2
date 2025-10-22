using System.Net.Sockets;
using Common.Cryptography;
using Common.Network;
using Serilog;

namespace LoginServer.Network.GameApplication.ClientsNetwork;

public class L2Connection : IDisposable
{
    protected readonly ILogger Logger = Log.Logger.ForContext<L2Connection>();
    private readonly NetworkStream networkStream;
    private readonly TcpClient tcpClient;

    protected INetworkCrypt Crypt { get; set; }
    
    public event Func<Packet, Task> ReceivedPacket;
    public event Func<Packet, Task> SendingPacket;
    
    public string Ip => tcpClient.Client.RemoteEndPoint?
        .ToString() ?? string.Empty;
    
    public L2Connection(TcpClient tcpClient)
    {
        this.tcpClient = tcpClient;
        networkStream = tcpClient.GetStream();
        Crypt = new LoginCrypt();
        
        ReceivedPacket += (packet) =>
        {
            Logger.Information(
                "L2Connection получил пакет:{FirstOpcode:X2}", 
                packet.FirstOpcode);

            return Task.CompletedTask;
        };
        
        SendingPacket += packet =>
        {
            Logger.Information(
                "L2Connection отправляет пакет:{FirstOpcode:X2}",
                packet.FirstOpcode);
            
            return Task.CompletedTask;
        };
    }

    /// <summary>
    /// Отправить пакет по соединению
    /// </summary>
    /// <param name="p"></param>
    /// <param name="encrypt">Шифровать сообщение?</param>
    /// <returns></returns>
    public async Task SendAsync(Packet p, bool encrypt = true)
    {
        await SendingPacket.Invoke(p);
        var data = p.GetBuffer();
        if (encrypt)
        {
            Crypt.Encrypt(data);
        }

        var lengthBytes = BitConverter.GetBytes((short)(data.Length + 2)); //TODO: не понимаю. Возможно надо убрать + 2
        var message = new byte[data.Length + 2];

        lengthBytes.CopyTo(message, 0);
        data.CopyTo(message, 2);

        await networkStream.WriteAsync(message, 0, message.Length);
        await networkStream.FlushAsync();
    }

    /// <summary>
    /// Цикл чтения пакетов из соединения
    /// </summary>
    /// <returns></returns>
    public async Task ReadAsync(CancellationToken ct)
    {
            try
            {
                while (!ct.IsCancellationRequested)
                {
                    var bodyLength = await ReadBodyLengthAsync(ct);

                    var body = new byte[bodyLength];
                    await ReadBodyAsync(body, bodyLength, ct);
                    var packet = new Packet(1, body);

                    await ReceivedPacket.Invoke(packet);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(
                    ex,
                    "Ошибка при чтении пакета: {Message}",
                    ex.Message);

                //TODO: Тут надо наверно закрывать соединение
            }
    }

    /// <summary>
    /// Получает длину пакета из первых двух байт
    /// </summary>
    private async Task<short> ReadBodyLengthAsync(CancellationToken ct)
    {
        var buffer = new byte[2];
        var bytesRead = await networkStream.ReadAsync(buffer, 0, 2, ct);

        //Возможно чтение 0 байт совершенно валидное поведение
        //И должно считаться корректным закрытием сокета на другой стороне
        //Подробнее по ссылке
        //https://blog.stephencleary.com/2009/06/using-socket-as-connected-socket.html
        if (bytesRead != 2)
            throw new Exception($"Пакет имеет поврежденную структуру : bytesRead = {bytesRead}");

        var length = BitConverter.ToInt16(buffer, 0);

        return (short)(length - 2); //TODO: избавиться от каста
    }

    /// <summary>
    /// Вычитывает пакет из потока
    /// </summary>
    /// <param name="body">Массив для заполнения</param>
    /// <param name="lenght">Длина пакета</param>
    /// <param name="ct">Токен отмены</param>
    private async Task ReadBodyAsync(
        byte[] body,
        short lenght,
        CancellationToken ct)
    {
        Console.WriteLine("---------");
        Console.WriteLine($"{lenght}");
        var bytesRead = await networkStream.ReadAsync(body, 0, lenght, ct);

        if (bytesRead != lenght)
            throw new Exception($"Пакет имеет поврежденную структуру : bytesRead = {bytesRead}");

        //TODO: Возможно расшифровку надо обернуть в try catch
        Crypt.Decrypt(ref body);
    }

    public void Dispose()
    {
        networkStream.Dispose();
        tcpClient.Dispose();
    }
}