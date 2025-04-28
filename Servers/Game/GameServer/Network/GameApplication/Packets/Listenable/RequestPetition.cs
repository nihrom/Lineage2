using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPetition
{
    public string Content;
    public int Type;

    public RequestPetition(Packet packet)
    {
        Content = packet.ReadString();
        Type = packet.ReadInt();
    }
}