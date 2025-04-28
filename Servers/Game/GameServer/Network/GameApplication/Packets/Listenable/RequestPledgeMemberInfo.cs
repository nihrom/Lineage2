using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPledgeMemberInfo
{
    public RequestPledgeMemberInfo(Packet packet)
    {
        var _unk1 = packet.ReadInt();
        var _player = packet.ReadString();
    }
}