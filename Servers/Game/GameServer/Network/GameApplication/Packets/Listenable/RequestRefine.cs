using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestRefine
{
    public RequestRefine(Packet packet)
    {
        var _targetItemObjId = packet.ReadInt();
        var _refinerItemObjId = packet.ReadInt();
        var _gemStoneItemObjId = packet.ReadInt();
        var _gemStoneCount = packet.ReadInt();
    }
}