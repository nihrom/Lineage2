using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class AddTradeItem
{
    public int TradeId { get; }
    
    public int ObjectId { get; }
    
    public int Count { get; }

    public AddTradeItem(Packet packet)
    {
        TradeId = packet.ReadInt();
        ObjectId = packet.ReadInt();
        Count = packet.ReadInt();
    }
}