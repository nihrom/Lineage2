using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestFriendDel
{
    public RequestFriendDel(Packet packet)
    {
        var _name = packet.ReadString();
    }
}