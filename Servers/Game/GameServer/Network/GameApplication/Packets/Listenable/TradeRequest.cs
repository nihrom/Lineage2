using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class TradeRequest
{
    public int ObjectId;

    public TradeRequest(Packet packet)
    {
        ObjectId = packet.ReadInt();
    }
}