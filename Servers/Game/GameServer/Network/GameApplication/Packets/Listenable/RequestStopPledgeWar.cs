using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestStopPledgeWar
{
    public RequestStopPledgeWar(Packet packet)
    {
        var _pledgeName = packet.ReadString();
    }
}