using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part12;

public class RequestOustPledgeMember
{
    public string Target;

    public RequestOustPledgeMember(Packet packet)
    {
        Target = packet.ReadString();
    }
}