using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestJoinPledge
{
    public RequestJoinPledge(Packet packet)
    {
        var _target = packet.ReadInt();
        var _pledgeType = packet.ReadInt();
    }
}