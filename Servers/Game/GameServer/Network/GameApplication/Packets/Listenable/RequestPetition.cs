using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPetition
{
    public RequestPetition(Packet packet)
    {
        _content = readString();
        _type = readInt();
    }
}