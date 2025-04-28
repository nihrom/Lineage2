using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestDropItem
{
    public int ObjectId;
    public int Count;
    public int X;
    public int Y;
    public int Z;

    public RequestDropItem(Packet packet)
    {
        ObjectId = packet.ReadInt();
        Count = packet.ReadInt();
        X = packet.ReadInt();
        Y = packet.ReadInt();
        Z = packet.ReadInt();
    }
}