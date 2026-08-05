using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part8;

public class RequestExMPCCShowPartyMembersInfo
{
    public int PartyLeaderId;

    public RequestExMPCCShowPartyMembersInfo(Packet packet)
    {
        PartyLeaderId = packet.ReadInt();
    }
}