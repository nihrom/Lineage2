using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestConfirmTargetItem
{
    public RequestConfirmTargetItem(Packet packet)
    {
        var _itemObjId = packet.ReadInt();
    }
}