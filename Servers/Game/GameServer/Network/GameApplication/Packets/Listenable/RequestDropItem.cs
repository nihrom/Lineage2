using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestDropItem
{
    public RequestDropItem(Packet packet)
    {
        var _objectId = packet.ReadInt();
        var _count = packet.ReadInt();
        var _x = packet.ReadInt();
        var _y = packet.ReadInt();
        var _z = packet.ReadInt();
    }
}