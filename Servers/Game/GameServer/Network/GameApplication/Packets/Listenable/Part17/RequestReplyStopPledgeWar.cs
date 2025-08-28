using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestReplyStopPledgeWar
{
    public int Answer;

    public RequestReplyStopPledgeWar(Packet packet)
    {
        packet.ReadString(); // _reqName
        Answer = packet.ReadInt();
    }
}