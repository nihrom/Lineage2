using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestAnswerFriendInvite
{
    public int Response;

    public RequestAnswerFriendInvite(Packet packet)
    {
        Response = packet.ReadInt();
    }
}