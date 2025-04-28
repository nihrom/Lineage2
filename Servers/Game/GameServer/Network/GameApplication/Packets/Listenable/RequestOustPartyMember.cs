using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestOustPartyMember
{
    public string Name;

    public RequestOustPartyMember(Packet packet)
    {
        Name = packet.ReadString();
    }
}