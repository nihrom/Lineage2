using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestSurrenderPledgeWar
{
    public string PledgeName;

    public RequestSurrenderPledgeWar(Packet packet)
    {
        PledgeName = packet.ReadString();
    }
}