using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestJoinParty
{
    public RequestJoinParty(Packet packet)
    {
        _name = readString();
        _partyDistributionTypeId = readInt();
    }
}