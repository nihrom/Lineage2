using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPledgeSetAcademyMaster
{
    public RequestPledgeSetAcademyMaster(Packet packet)
    {
        var _set = packet.ReadInt();
        var _currPlayerName = packet.ReadString();
        var _targetPlayerName = packet.ReadString();
    }
}