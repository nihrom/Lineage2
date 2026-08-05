using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part6;

public class RequestCrystallizeItem
{
    public int ObjectId;
    public int Count;

    public RequestCrystallizeItem(Packet packet)
    {
        ObjectId = packet.ReadInt();
        Count = packet.ReadInt();
    }
}