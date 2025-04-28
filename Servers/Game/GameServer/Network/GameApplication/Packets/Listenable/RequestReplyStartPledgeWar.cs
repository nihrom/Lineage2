using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestReplyStartPledgeWar
{
    public int Answer;

    public RequestReplyStartPledgeWar(Packet packet)
    {
        packet.ReadString(); // _reqName
        Answer = packet.ReadInt();
    }
}