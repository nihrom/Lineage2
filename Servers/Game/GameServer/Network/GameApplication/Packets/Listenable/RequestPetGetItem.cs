using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPetGetItem
{
    public int ObjectId;

    public RequestPetGetItem(Packet packet)
    {
        ObjectId = packet.ReadInt();
    }
}