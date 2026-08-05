using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part13;

public class RequestPetUseItem
{
    public int ObjectId;

    public RequestPetUseItem(Packet packet)
    {
        ObjectId = packet.ReadInt();
        // TODO: implement me properly
        // readLong();
        // readInt();
    }
}