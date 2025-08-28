using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestSiegeDefenderList
{
    public int CastleId;

    public RequestSiegeDefenderList(Packet packet)
    {
        CastleId = packet.ReadInt();
    }
}