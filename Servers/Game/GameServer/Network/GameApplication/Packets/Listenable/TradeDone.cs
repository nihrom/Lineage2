using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class TradeDone
{
    public TradeDone(Packet packet)
    {
        _response = readInt();
    }
}