using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestDestroyItem
{
    public int ObjectId;
    public int Count;

    public RequestDestroyItem(Packet packet)
    {
        ObjectId = packet.ReadInt();
        Count = packet.ReadInt();
    }
}