using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestSetCastleSiegeTime
{
    public RequestSetCastleSiegeTime(Packet packet)
    {
        var _castleId = packet.ReadInt();
        var _time = packet.ReadInt();
        _time *= 1000;
    }
}