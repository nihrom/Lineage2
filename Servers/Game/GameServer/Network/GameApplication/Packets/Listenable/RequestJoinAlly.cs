using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestJoinAlly
{
    public RequestJoinAlly(Packet packet)
    {
        _id = readInt();
    }
}