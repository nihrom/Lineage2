using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestConfirmSiegeWaitingList
{
    public RequestConfirmSiegeWaitingList(Packet packet)
    {
        var _castleId = packet.ReadInt();
        var _clanId = packet.ReadInt();
        var _approved = packet.ReadInt();
    }
}