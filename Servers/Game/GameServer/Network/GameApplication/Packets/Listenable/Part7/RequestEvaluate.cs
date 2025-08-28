using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestEvaluate
{
    public RequestEvaluate(Packet packet)
    {
        packet.ReadInt(); // target Id
    }
}