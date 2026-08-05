using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part11;

public class RequestJoinParty
{
    public string Name;
    public int PartyDistributionTypeId;

    public RequestJoinParty(Packet packet)
    {
        Name = packet.ReadString();
        PartyDistributionTypeId = packet.ReadInt();
    }
}