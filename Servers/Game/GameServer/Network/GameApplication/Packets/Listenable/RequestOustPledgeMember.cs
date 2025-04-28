using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestOustPledgeMember
{
    public RequestOustPledgeMember(Packet packet)
    {
        _target = readString();
    }
}