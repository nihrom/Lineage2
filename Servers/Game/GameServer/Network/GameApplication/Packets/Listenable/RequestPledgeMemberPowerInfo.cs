using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPledgeMemberPowerInfo
{
    public RequestPledgeMemberPowerInfo(Packet packet)
    {
        var _unk1 = packet.ReadInt();
        var _player = packet.ReadString();
    }
}