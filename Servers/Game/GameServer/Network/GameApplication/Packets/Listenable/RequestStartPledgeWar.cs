using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestStartPledgeWar
{
    public RequestStartPledgeWar(Packet packet)
    {
        _pledgeName = readString();
    }
}