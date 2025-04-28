using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestRestartPoint
{
    public RequestRestartPoint(Packet packet)
    {
        _requestedPointType = readInt();
    }
}