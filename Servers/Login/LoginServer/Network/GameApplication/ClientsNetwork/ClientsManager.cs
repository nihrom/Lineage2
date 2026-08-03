using System.Net.Sockets;
using Serilog;

namespace LoginServer.Network.GameApplication.ClientsNetwork;

public class ClientsManager
{
    private readonly ILogger logger;
    private readonly PacketHandlersBuilder packetHandlersBuilder;
    private readonly TestHandler testHandler;

    public ClientsManager(
        ILogger logger,
        PacketHandlersBuilder packetHandlersBuilder,
        TestHandler testHandler)
    {
        this.logger = logger;
        this.packetHandlersBuilder = packetHandlersBuilder;
        this.testHandler = testHandler;
    }

    public async Task AcceptClient(TcpClient client, CancellationToken ct)
    {
        logger.Information(
            "Получен запрос на подключение от: {RemoteEndPoint}",
            client.Client.RemoteEndPoint?.ToString());

        var l2Client = new L2GameApplicationAvatar(
            client,
            packetHandlersBuilder,
            testHandler);
        await l2Client.Init();
    }
}