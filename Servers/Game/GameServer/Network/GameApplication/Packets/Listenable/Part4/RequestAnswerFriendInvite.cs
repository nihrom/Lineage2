using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part4;

public class RequestAnswerFriendInvite
{
    public int Response;

    public RequestAnswerFriendInvite(Packet packet)
    {
        Response = packet.ReadInt();
    }
}