using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestConfirmGemStone
{
    public RequestConfirmGemStone(Packet packet)
    {
        var _targetItemObjId = packet.ReadInt();
        var _refinerItemObjId = packet.ReadInt();
        var _gemstoneItemObjId = packet.ReadInt();
        var _gemStoneCount = packet.ReadInt();
    }
}