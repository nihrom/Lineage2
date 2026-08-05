using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part7;

public class RequestEvaluate
{
    public RequestEvaluate(Packet packet)
    {
        packet.ReadInt(); // target Id
    }
}