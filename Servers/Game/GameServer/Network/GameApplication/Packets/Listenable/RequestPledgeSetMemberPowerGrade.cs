using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPledgeSetMemberPowerGrade
{
    public RequestPledgeSetMemberPowerGrade(Packet packet)
    {
        var _member = packet.ReadString();
        var _powerGrade = packet.ReadInt();
    }
}