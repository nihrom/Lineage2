using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestAnswerJoinPledge
{
    public RequestAnswerJoinPledge(Packet packet)
    {
        var _answer = packet.ReadInt();
    }
}