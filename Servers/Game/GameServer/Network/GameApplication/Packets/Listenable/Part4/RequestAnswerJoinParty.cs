using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestAnswerJoinParty
{
    public int Response;

    public RequestAnswerJoinParty(Packet packet)
    {
        Response = packet.ReadInt();
    }
}