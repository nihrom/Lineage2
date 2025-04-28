using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestReplyStartPledgeWar
{
    public RequestReplyStartPledgeWar(Packet packet)
    {
        readString(); // _reqName
        var _answer = packet.ReadInt();
    }
}