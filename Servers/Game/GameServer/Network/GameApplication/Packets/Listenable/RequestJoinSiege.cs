using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestJoinSiege
{
    public int CastleId;
    public int IsAttacker;
    public int IsJoining;

    public RequestJoinSiege(Packet packet)
    {
        CastleId = packet.ReadInt();
        IsAttacker = packet.ReadInt();
        IsJoining = packet.ReadInt();
    }
}