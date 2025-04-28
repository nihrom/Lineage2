using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestCrystallizeItem
{
    public RequestCrystallizeItem(Packet packet)
    {
        var _objectId = packet.ReadInt();
        var _count = packet.ReadInt();
    }
}