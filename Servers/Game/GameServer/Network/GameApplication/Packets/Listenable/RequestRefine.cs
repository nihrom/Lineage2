using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestRefine
{
    public int TargetItemObjId;
    public int RefinerItemObjId;
    public int GemStoneItemObjId;
    public int GemStoneCount;

    public RequestRefine(Packet packet)
    {
        TargetItemObjId = packet.ReadInt();
        RefinerItemObjId = packet.ReadInt();
        GemStoneItemObjId = packet.ReadInt();
        GemStoneCount = packet.ReadInt();
    }
}