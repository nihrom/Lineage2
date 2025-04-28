using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestJoinSiege
{
    public RequestJoinSiege(Packet packet)
    {
        var _castleId = packet.ReadInt();
        var _isAttacker = packet.ReadInt();
        var _isJoining = packet.ReadInt();
    }
}