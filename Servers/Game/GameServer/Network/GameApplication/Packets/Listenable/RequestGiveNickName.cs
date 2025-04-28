using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestGiveNickName
{
    public RequestGiveNickName(Packet packet)
    {
        _target = readString();
        _title = readString();
    }
}