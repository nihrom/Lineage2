using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPetUseItem
{
    public RequestPetUseItem(Packet packet)
    {
        var _objectId = packet.ReadInt();
        // TODO: implement me properly
        // readLong();
        // readInt();
    }
}