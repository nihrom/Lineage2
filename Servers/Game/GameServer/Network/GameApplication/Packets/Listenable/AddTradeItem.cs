using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class AddTradeItem
{
    public int TradeId;
    public int ObjectId;
    public int Count;

    public AddTradeItem(Packet packet)
    {
        TradeId = packet.ReadInt();
        ObjectId = packet.ReadInt();
        Count = packet.ReadInt();
    }
}