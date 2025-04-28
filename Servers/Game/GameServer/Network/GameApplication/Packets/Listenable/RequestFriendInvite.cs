using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestFriendInvite
{
    public RequestFriendInvite(Packet packet)
    {
        var _name = packet.ReadString();
    }
}