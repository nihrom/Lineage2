using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part9;

public class RequestFriendDel
{
    public string Name;

    public RequestFriendDel(Packet packet)
    {
        Name = packet.ReadString();
    }
}