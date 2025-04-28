using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPetUseItem
{
    public RequestPetUseItem(Packet packet)
    {
        _objectId = readInt();
        // TODO: implement me properly
        // readLong();
        // readInt();
    }
}