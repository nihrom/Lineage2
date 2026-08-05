using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part17;

public class RequestRestartPoint
{
    public int RequestedPointType;

    public RequestRestartPoint(Packet packet)
    {
        RequestedPointType = packet.ReadInt();
    }
}