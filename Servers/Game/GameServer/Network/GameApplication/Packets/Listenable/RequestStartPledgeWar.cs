using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestStartPledgeWar
{
    public string PledgeName;

    public RequestStartPledgeWar(Packet packet)
    {
        PledgeName = packet.ReadString();
    }
}