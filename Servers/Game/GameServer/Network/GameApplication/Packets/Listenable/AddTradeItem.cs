using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class AddTradeItem
{
    public AddTradeItem(Packet packet)
    {
        var _tradeId = packet.ReadInt();
        var _objectId = packet.ReadInt();
        var _count = packet.ReadInt();
    }
}