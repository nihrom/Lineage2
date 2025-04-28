using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestReplyStopPledgeWar
{
    public RequestReplyStopPledgeWar(Packet packet)
    {
        readString(); // _reqName
        _answer = readInt();
    }
}