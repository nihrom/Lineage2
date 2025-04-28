using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPledgeMemberPowerInfo
{
    public RequestPledgeMemberPowerInfo(Packet packet)
    {
        _unk1 = readInt();
        _player = readString();
    }
}