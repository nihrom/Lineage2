using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class TradeDone
{
    public TradeDone(Packet packet)
    {
        var _response = packet.ReadInt();
    }
}