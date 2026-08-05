using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part20;

public class RequestTutorialClientEvent
{
    public int EventId1;

    public RequestTutorialClientEvent(Packet packet)
    {
        EventId1 = packet.ReadInt();
    }
}