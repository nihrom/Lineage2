using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestDestroyItem
{
    public RequestDestroyItem(Packet packet)
    {
        var _objectId = packet.ReadInt();
        var _count = packet.ReadInt();
    }
}