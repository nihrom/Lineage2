using System.Net.Sockets;
using Serilog;

namespace GameServer.Network.GameApplication.ClientsNetwork;

public class ClientsManager
{
    private readonly ILogger logger;
    private readonly PacketHandlersBuilder packetHandlersBuilder;

    public ClientsManager(ILogger logger, PacketHandlersBuilder packetHandlersBuilder)
    {
        this.logger = logger;
        this.packetHandlersBuilder = packetHandlersBuilder;
    }
    
    public async Task AcceptClient(TcpClient client, CancellationToken ct)
    {
        logger.Information(
            "Получен запрос на подключение от: {RemoteEndPoint}",
            client.Client.RemoteEndPoint?.ToString());

        var l2Client = new L2GameApplicationAvatar(client, packetHandlersBuilder);
        await l2Client.Init();
    }
}