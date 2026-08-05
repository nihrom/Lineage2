using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part11;

public class RequestLinkHtml
{
    public string Link;

    public RequestLinkHtml(Packet packet)
    {
        Link = packet.ReadString();
    }
}