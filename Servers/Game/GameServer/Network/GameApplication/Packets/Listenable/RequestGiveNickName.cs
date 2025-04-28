using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestGiveNickName
{
    public RequestGiveNickName(Packet packet)
    {
        var _target = packet.ReadString();
        var _title = packet.ReadString();
    }
}