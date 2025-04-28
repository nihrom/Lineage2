using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestTutorialPassCmdToServer
{
    public RequestTutorialPassCmdToServer(Packet packet)
    {
        _bypass = readString();
    }
}