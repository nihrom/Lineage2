using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part6;

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