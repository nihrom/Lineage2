using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestTutorialLinkHtml
{
    public RequestTutorialLinkHtml(Packet packet)
    {
        var _bypass = packet.ReadString();
    }
}