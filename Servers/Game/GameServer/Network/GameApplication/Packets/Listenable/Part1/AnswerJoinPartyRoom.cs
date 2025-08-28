using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class AnswerJoinPartyRoom
{
    public int Answer;

    public AnswerJoinPartyRoom(Packet packet)
    {
        Answer = packet.ReadInt();
    }
}