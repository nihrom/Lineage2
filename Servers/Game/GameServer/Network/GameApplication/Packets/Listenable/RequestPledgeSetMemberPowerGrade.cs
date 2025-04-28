using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPledgeSetMemberPowerGrade
{
    public RequestPledgeSetMemberPowerGrade(Packet packet)
    {
        _member = readString();
        _powerGrade = readInt();
    }
}