using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestStopPledgeWar
{
    public string PledgeName;

    public RequestStopPledgeWar(Packet packet)
    {
        PledgeName = packet.ReadString();
    }
}