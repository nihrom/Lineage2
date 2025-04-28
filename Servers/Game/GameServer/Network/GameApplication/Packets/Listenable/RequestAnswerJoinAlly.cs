using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestAnswerJoinAlly
{
    public RequestAnswerJoinAlly(Packet packet)
    {
        var _response = packet.ReadInt();
    }
}