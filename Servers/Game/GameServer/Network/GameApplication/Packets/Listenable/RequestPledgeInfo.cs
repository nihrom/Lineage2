using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPledgeInfo
{
    public int ClanId;

    public RequestPledgeInfo(Packet packet)
    {
        ClanId = packet.ReadInt();
    }
}