using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class AnswerTradeRequest
{
    public int Response;

    public AnswerTradeRequest(Packet packet)
    {
        Response = packet.ReadInt();
    }
}