using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestSurrenderPledgeWar
{
    public RequestSurrenderPledgeWar(Packet packet)
    {
        _pledgeName = readString();
    }
}