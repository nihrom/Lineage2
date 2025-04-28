using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestExMPCCShowPartyMembersInfo
{
    public RequestExMPCCShowPartyMembersInfo(Packet packet)
    {
        _partyLeaderId = readInt();
    }
}