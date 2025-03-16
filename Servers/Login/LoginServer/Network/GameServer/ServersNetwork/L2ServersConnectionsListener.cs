using System.Net;
using System.Net.Sockets;
using Microsoft.Extensions.Options;
using Serilog;

namespace LoginServer.ServersNetwork;

public class L2ServersConnectionsListener
{
    private readonly ILogger logger;
    private readonly TcpListener tcpListener;
    
    public L2ServersConnectionsListener(IOptions<ServerConfig> serverConfig, ILogger logger)
    {
        var config = serverConfig.Value;

        if (string.IsNullOrEmpty(config.Host))
            throw new ArgumentException("В настройках сервера не указан адрес прослушивания соединений");
        
        if(config.GameServersPort == 0)
            throw new ArgumentException(
                "В настройках сервера не указан порт прослушивания соединений",
                nameof(config.GameServersPort));
        
        this.logger = logger;
        
        tcpListener = new TcpListener(
            IPAddress.Parse(config.Host),
            config.GameServersPort);
    }
    
    public void Start()
    {
        logger.Information("Прослушка для подключения серверов запускается");

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
            "Логин Сервер слушает подключаемые сервера на {LocalEndpoint}",
            tcpListener.LocalEndpoint.ToString());
        
        //TODO: CancellationToken
        _ = WaitForClients(CancellationToken.None);
        
        logger.Information("Прослушка для подключения серверов запустилась");
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
                logger.Error(e, "Не удалось принять подключение");
                throw;
            }
        }
    }
    
    private async Task AcceptClient(TcpClient client, CancellationToken ct)
    {
        logger.Information(
            "Получен запрос на подключение от: {RemoteEndPoint}",
            client.Client.RemoteEndPoint?.ToString());
        
        var l2GameServerAvatar = new L2GameServerAvatar(client);
        
        await l2GameServerAvatar.Init();
        
        _ = Task
            .Run(
                () => l2GameServerAvatar.ReadAsync(ct), 
                CancellationToken.None)
            .ContinueWith(
                _ => l2GameServerAvatar.Dispose(),
                CancellationToken.None)
            .ContinueWith(
                _ => logger.Information("Server client disposed"),
                CancellationToken.None);
    }
    
    public void Stop()
    {
        logger.Information("Прослушка подключаемых серверов завершается");
        tcpListener.Server.Close();
        //TODO: реализовать остановку сетевого общения с пользователями
        logger.Information("Прослушка подключаемых серверов завершилась");
    }
}