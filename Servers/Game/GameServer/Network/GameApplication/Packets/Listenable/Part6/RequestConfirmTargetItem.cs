using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestConfirmTargetItem
{
    public int ItemObjId;

    public RequestConfirmTargetItem(Packet packet)
    {
        ItemObjId = packet.ReadInt();
    }
}