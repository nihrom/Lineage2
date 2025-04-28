using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPetGetItem
{
    public RequestPetGetItem(Packet packet)
    {
        _objectId = readInt();
    }
}