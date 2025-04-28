using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestReplyStopPledgeWar
{
    public RequestReplyStopPledgeWar(Packet packet)
    {
        readString(); // _reqName
        var _answer = packet.ReadInt();
    }
}