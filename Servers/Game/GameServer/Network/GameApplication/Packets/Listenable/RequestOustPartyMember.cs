using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestOustPartyMember
{
    public RequestOustPartyMember(Packet packet)
    {
        var _name = packet.ReadString();
    }
}