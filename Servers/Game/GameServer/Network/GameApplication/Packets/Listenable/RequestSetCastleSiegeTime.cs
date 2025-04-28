using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestSetCastleSiegeTime
{
    public RequestSetCastleSiegeTime(Packet packet)
    {
        _castleId = readInt();
        _time = readInt();
        _time *= 1000;
    }
}