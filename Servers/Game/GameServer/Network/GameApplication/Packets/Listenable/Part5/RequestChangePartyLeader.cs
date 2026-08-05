using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part5;

public class RequestChangePartyLeader
{
    public string Name;

    public RequestChangePartyLeader(Packet packet)
    {
        Name = packet.ReadString();
    }
}