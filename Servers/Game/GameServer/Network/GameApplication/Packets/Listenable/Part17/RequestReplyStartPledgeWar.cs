using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part17;

public class RequestReplyStartPledgeWar
{
    public int Answer;

    public RequestReplyStartPledgeWar(Packet packet)
    {
        packet.ReadString(); // _reqName
        Answer = packet.ReadInt();
    }
}