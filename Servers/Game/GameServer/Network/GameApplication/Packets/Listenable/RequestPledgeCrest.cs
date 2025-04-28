using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPledgeCrest
{
    public RequestPledgeCrest(Packet packet)
    {
        _crestId = readInt();
    }
}