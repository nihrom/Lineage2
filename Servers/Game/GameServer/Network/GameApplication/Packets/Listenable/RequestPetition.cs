using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPetition
{
    public RequestPetition(Packet packet)
    {
        var _content = packet.ReadString();
        var _type = packet.ReadInt();
    }
}