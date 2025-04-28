using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPledgeSetAcademyMaster
{
    public RequestPledgeSetAcademyMaster(Packet packet)
    {
        _set = readInt();
        _currPlayerName = readString();
        _targetPlayerName = readString();
    }
}