using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestJoinSiege
{
    public RequestJoinSiege(Packet packet)
    {
        _castleId = readInt();
        _isAttacker = readInt();
        _isJoining = readInt();
    }
}