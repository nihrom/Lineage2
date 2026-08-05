using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part1;

public class AnswerTradeRequest
{
    public int Response;

    public AnswerTradeRequest(Packet packet)
    {
        Response = packet.ReadInt();
    }
}