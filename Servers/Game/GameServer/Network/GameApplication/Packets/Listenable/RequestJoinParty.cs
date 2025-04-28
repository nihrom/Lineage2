using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestJoinParty
{
    public RequestJoinParty(Packet packet)
    {
        var _name = packet.ReadString();
        var _partyDistributionTypeId = packet.ReadInt();
    }
}