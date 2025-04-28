using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class TradeRequest
{
    public TradeRequest(Packet packet)
    {
        var _objectId = packet.ReadInt();
    }
}