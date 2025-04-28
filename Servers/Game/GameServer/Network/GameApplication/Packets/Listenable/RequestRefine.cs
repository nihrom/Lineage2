using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestRefine
{
    public RequestRefine(Packet packet)
    {
        _targetItemObjId = readInt();
        _refinerItemObjId = readInt();
        _gemStoneItemObjId = readInt();
        _gemStoneCount = readInt();
    }
}