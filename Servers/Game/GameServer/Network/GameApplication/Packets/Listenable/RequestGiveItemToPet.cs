using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestGiveItemToPet
{
    public int ObjectId;
    public int Amount;

    public RequestGiveItemToPet(Packet packet)
    {
        ObjectId = packet.ReadInt();
        Amount = packet.ReadInt();
    }
}