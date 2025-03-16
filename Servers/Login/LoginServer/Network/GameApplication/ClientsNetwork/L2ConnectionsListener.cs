using System.Net;
using System.Net.Sockets;
using Microsoft.Extensions.Options;
using Serilog;

namespace LoginServer.Network.GameApplication.ClientsNetwork;

public class L2ConnectionsListener
{
    private readonly ILogger logger;
    private readonly TcpListener tcpListener;

    public L2ConnectionsListener(IOptions<ServerConfig> serverConfig, ILogger logger)
    {
        var config = serverConfig.Value;

        if (string.IsNullOrEmpty(config.Host))
            throw new ArgumentException("В настройках сервера не указан адрес прослушивания соединений");
        
        if(config.Port == 0)
            throw new ArgumentException("В настройках сервера не указан порт прослушивания соединений");
        
        this.logger = logger;
        
        tcpListener = new TcpListener(
            IPAddress.Parse(config.Host),
            config.Port);
    }

    public void Start()
    {
        logger.Information("Прослушка входящих соединений запускается");

        try
        {
            tcpListener.Start();
        }
        catch (SocketException ex)
        {
            logger.Error(
                "Ошибка в сокете: {SocketErrorCode}. Сообщение: {Message} (Код ошибки: {NativeErrorCode})",
                ex.SocketErrorCode,
                ex.Message,
                ex.NativeErrorCode);
            
            logger.Information("Нажмите ENTER для завершения...");
            
            Console.Read();
            Environment.Exit(0);
        }

        logger.Information(
            "Логин Сервер слушает входящих клиентов на {LocalEndpoint}",
            tcpListener.LocalEndpoint.ToString());
        
        //TODO: CancellationToken
        _ = WaitForClients(CancellationToken.None);
        
        logger.Information("Прослушка входящих соединений запустилась");
    }
    
    private async Task WaitForClients(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            try
            {
                var client = await tcpListener.AcceptTcpClientAsync(ct);
                await AcceptClient(client, ct);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
    
    private async Task AcceptClient(TcpClient client, CancellationToken ct)
    {
        logger.Information(
            "Получен запрос на подключение от: {RemoteEndPoint}",
            client.Client.RemoteEndPoint?.ToString());
        
        var connection = new L2Connection(client);
        var loginController = new LoginController(connection);
        
        await loginController.Init();

        Task.Run(() => connection.ReadAsync(ct))
            .ContinueWith(
                _ => client.Dispose(),
                CancellationToken.None)
            .ContinueWith(
                _ => logger.Information("Client disposed"),
                CancellationToken.None);
    }
    
    public void Stop()
    {
        logger.Information("Прослушка входящих соединений завершается");
        tcpListener.Server.Close();
        //TODO: реализовать остановку сетевого общения с пользователями
        logger.Information("Прослушка входящих соединений завершилась");
    }
}