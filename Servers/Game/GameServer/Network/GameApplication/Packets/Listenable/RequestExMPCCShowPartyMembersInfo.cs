using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestExMPCCShowPartyMembersInfo
{
    public RequestExMPCCShowPartyMembersInfo(Packet packet)
    {
        var _partyLeaderId = packet.ReadInt();
    }
}