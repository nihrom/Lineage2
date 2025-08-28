using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestConfirmSiegeWaitingList
{
    public int CastleId;
    public int ClanId;
    public int Approved;

    public RequestConfirmSiegeWaitingList(Packet packet)
    {
        CastleId = packet.ReadInt();
        ClanId = packet.ReadInt();
        Approved = packet.ReadInt();
    }
}