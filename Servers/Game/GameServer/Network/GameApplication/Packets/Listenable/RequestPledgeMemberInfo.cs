using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPledgeMemberInfo
{
    public RequestPledgeMemberInfo(Packet packet)
    {
        _unk1 = readInt();
        _player = readString();
    }
}