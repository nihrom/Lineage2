using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestTutorialClientEvent
{
    public RequestTutorialClientEvent(Packet packet)
    {
        var eventId = packet.ReadInt();
    }
}