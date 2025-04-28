using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestReplySurrenderPledgeWar
{
    public RequestReplySurrenderPledgeWar(Packet packet)
    {
        _reqName = readString();
        _answer = readInt();
    }
}