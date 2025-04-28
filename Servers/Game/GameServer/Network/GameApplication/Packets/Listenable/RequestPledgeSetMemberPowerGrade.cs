using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPledgeSetMemberPowerGrade
{
    public string Member;
    public int PowerGrade;

    public RequestPledgeSetMemberPowerGrade(Packet packet)
    {
        Member = packet.ReadString();
        PowerGrade = packet.ReadInt();
    }
}