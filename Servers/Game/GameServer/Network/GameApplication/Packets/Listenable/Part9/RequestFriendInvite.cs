using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestFriendInvite
{
    public string Name;

    public RequestFriendInvite(Packet packet)
    {
        Name = packet.ReadString();
    }
}