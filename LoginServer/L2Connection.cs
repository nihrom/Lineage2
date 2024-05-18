using System.Net.Sockets;
using Common.Cryptography;
using Common.Network;
using Serilog;

namespace LoginServer;

public class L2Connection : IDisposable
{
    private readonly ILogger logger = Log.Logger.ForContext<L2Connection>();
    private readonly NetworkStream networkStream;
    private readonly TcpClient tcpClient;

    public INetworkCrypt? Crypt { get; set; }
    
    public event Action<Packet>? ReceivedPacket;
    public event Action<Packet>? SendingPacket;
    
    public L2Connection(TcpClient tcpClient, INetworkCrypt? crypt = null)
    {
        this.tcpClient = tcpClient;
        networkStream = tcpClient.GetStream();
        Crypt = crypt;
        
        ReceivedPacket += packet => logger.Information(
            "L2Connection получил пакет:{FirstOpcode:X2}",
            packet.FirstOpcode);
        
        SendingPacket += packet => logger.Information(
            "L2Connection отправляет пакет:{FirstOpcode:X2}",
            packet.FirstOpcode);
    }

    /// <summary>
    /// Отправить пакет по соединению
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public async Task SendAsync(Packet p)
    {
        SendingPacket?.Invoke(p);
        var data = p.GetBuffer();
        Crypt?.Encrypt(data);

        var lengthBytes = BitConverter.GetBytes((short)(data.Length + 2));
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
        while (!ct.IsCancellationRequested)
        {
            try
            {
                var bodyLength = await ReadBodyLengthAsync(ct);

                var body = new byte[bodyLength];
                await ReadBodyAsync(body, bodyLength);
                var packet = new Packet(1, body);

                ReceivedPacket?.Invoke(packet);
            }
            catch (Exception ex)
            {
                logger.Error(
                    ex,
                    "Ошибка при чтении пакета: {Message}",
                    ex.Message);

                //TODO: Тут надо наверно закрывать соединение
            }
        }
    }

    /// <summary>
    /// Получает длину пакета из первых двух байт
    /// </summary>
    private async Task<short> ReadBodyLengthAsync(CancellationToken ct)
    {
        var buffer = new byte[2];
        var bytesRead = await networkStream.ReadAsync(buffer, 0, 2, ct);

        if (bytesRead != 2)
            throw new Exception("Пакет имеет поврежденную структуру");

        var length = BitConverter.ToInt16(buffer, 0);

        return (short)(length - 2); //TODO: избавиться от каста
    }

    /// <summary>
    /// Заполняет массив телом пакета
    /// </summary>
    /// <param name="body">Массив для заполнения</param>
    /// <param name="lenght">Длина пакета</param>
    private async Task ReadBodyAsync(byte[] body, short lenght)
    {
        var bytesRead = await networkStream.ReadAsync(body, 0, lenght);

        if (bytesRead != lenght)
            throw new Exception("Пакет имеет поврежденную структуру");

        //TODO: Возможно расшифровку надо обернуть в try catch
        Crypt?.Decrypt(body);
    }

    public void Dispose()
    {
        networkStream.Dispose();
        tcpClient.Dispose();
    }
}