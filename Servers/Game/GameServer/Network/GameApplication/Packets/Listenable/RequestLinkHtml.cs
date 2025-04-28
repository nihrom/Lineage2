using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestLinkHtml
{
    public RequestLinkHtml(Packet packet)
    {
        _link = readString();
    }
}