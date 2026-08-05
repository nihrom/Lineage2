using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part12;

public class RequestOustPartyMember
{
    public string Name;

    public RequestOustPartyMember(Packet packet)
    {
        Name = packet.ReadString();
    }
}