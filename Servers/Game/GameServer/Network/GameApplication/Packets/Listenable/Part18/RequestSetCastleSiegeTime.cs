using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestSetCastleSiegeTime
{
    public int CastleId;
    public int Time;

    public RequestSetCastleSiegeTime(Packet packet)
    {
        CastleId = packet.ReadInt();
        Time = packet.ReadInt();
        Time *= 1000;
    }
}