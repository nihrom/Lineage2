using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPledgeInfo
{
    public RequestPledgeInfo(Packet packet)
    {
        var _clanId = packet.ReadInt();
    }
}