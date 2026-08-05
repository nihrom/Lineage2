using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part7;

public class RequestEnchantItem
{
    public int ObjectId;

    public RequestEnchantItem(Packet packet)
    {
        ObjectId = packet.ReadInt();
    }
}