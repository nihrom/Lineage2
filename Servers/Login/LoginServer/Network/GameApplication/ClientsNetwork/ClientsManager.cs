using System.Net.Sockets;
using Serilog;

namespace LoginServer.Network.GameApplication.ClientsNetwork;

public class ClientsManager
{
    private readonly ILogger logger;
    private readonly TestHandler testHandler;

    public ClientsManager(
        ILogger logger,
        TestHandler testHandler)
    {
        this.logger = logger;
        this.testHandler = testHandler;
    }

    public async Task AcceptClient(TcpClient client, CancellationToken ct)
    {
        logger.Information(
            "Получен запрос на подключение от: {RemoteEndPoint}",
            client.Client.RemoteEndPoint?.ToString());

        var l2Client = new L2GameApplicationAvatar(
            client,
            testHandler);
        await l2Client.Init();
    }
}