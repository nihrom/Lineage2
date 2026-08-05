using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part11;

public class RequestJoinPledge
{
    public int Target;
    public int PledgeType;

    public RequestJoinPledge(Packet packet)
    {
        Target = packet.ReadInt();
        PledgeType = packet.ReadInt();
    }
}