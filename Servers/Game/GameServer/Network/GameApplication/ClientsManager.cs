using System.Net.Sockets;
using Serilog;

namespace GameServer.Network.GameApplication;

public class ClientsManager
{
    private readonly ILogger logger;
    private readonly GameApplicationPacketHandler gameApplicationPacketHandler;

    public ClientsManager(
        ILogger logger,
        GameApplicationPacketHandler gameApplicationPacketHandler)
    {
        this.logger = logger;
        this.gameApplicationPacketHandler = gameApplicationPacketHandler;
    }
    
    public async Task AcceptClient(TcpClient client, CancellationToken ct)
    {
        logger.Information(
            "Получен запрос на подключение от: {RemoteEndPoint}",
            client.Client.RemoteEndPoint?.ToString());

        var l2Client = new L2GameApplicationAvatar(client, gameApplicationPacketHandler);
        await l2Client.Init();
    }
}