using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestChangePartyLeader
{
    public string Name;

    public RequestChangePartyLeader(Packet packet)
    {
        Name = packet.ReadString();
    }
}