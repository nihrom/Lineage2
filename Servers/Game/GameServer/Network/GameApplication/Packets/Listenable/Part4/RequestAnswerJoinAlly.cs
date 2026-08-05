using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part4;

public class RequestAnswerJoinAlly
{
    public int Response;

    public RequestAnswerJoinAlly(Packet packet)
    {
        Response = packet.ReadInt();
    }
}