using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestConfirmGemStone
{
    public int TargetItemObjId;
    public int RefinerItemObjId;
    public int GemstoneItemObjId;
    public int GemStoneCount;

    public RequestConfirmGemStone(Packet packet)
    {
        TargetItemObjId = packet.ReadInt();
        RefinerItemObjId = packet.ReadInt();
        GemstoneItemObjId = packet.ReadInt();
        GemStoneCount = packet.ReadInt();
    }
}