using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestConfirmRefinerItem
{
    public RequestConfirmRefinerItem(Packet packet)
    {
        var _targetItemObjId = packet.ReadInt();
        var _refinerItemObjId = packet.ReadInt();
    }
}