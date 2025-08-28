using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestSiegeAttackerList
{
    public int CastleId;

    public RequestSiegeAttackerList(Packet packet)
    {
        CastleId = packet.ReadInt();
    }
}