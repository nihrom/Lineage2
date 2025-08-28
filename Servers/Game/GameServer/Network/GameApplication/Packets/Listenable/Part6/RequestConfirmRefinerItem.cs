using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestConfirmRefinerItem
{
    public int TargetItemObjId;
    public int RefinerItemObjId;

    public RequestConfirmRefinerItem(Packet packet)
    {
        TargetItemObjId = packet.ReadInt();
        RefinerItemObjId = packet.ReadInt();
    }
}