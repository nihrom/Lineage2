using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part10;

public class RequestJoinAlly
{
    public int Id;

    public RequestJoinAlly(Packet packet)
    {
        Id = packet.ReadInt();
    }
}