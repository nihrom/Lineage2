using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestAnswerFriendInvite
{
    public RequestAnswerFriendInvite(Packet packet)
    {
        var _response = packet.ReadInt();
    }
}