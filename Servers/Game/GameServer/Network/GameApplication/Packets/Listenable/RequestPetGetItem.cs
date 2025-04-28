using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPetGetItem
{
    public RequestPetGetItem(Packet packet)
    {
        var _objectId = packet.ReadInt();
    }
}