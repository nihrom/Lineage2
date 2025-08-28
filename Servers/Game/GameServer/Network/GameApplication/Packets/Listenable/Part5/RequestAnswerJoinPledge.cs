using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestAnswerJoinPledge
{
    public int Answer;

    public RequestAnswerJoinPledge(Packet packet)
    {
        Answer = packet.ReadInt();
    }
}