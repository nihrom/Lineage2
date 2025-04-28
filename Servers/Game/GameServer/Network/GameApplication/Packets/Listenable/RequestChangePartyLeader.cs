using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestChangePartyLeader
{
    public RequestChangePartyLeader(Packet packet)
    {
        var _name = packet.ReadString();
    }
}