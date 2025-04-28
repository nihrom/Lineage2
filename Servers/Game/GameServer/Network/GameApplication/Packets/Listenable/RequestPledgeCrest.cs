using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPledgeCrest
{
    public RequestPledgeCrest(Packet packet)
    {
        var _crestId = packet.ReadInt();
    }
}