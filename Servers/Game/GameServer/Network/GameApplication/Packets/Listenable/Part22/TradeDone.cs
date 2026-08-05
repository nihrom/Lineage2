using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part22;

public class TradeDone
{
    public int Response;

    public TradeDone(Packet packet)
    {
        Response = packet.ReadInt();
    }
}