using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestFriendDel
{
    public string Name;

    public RequestFriendDel(Packet packet)
    {
        Name = packet.ReadString();
    }
}