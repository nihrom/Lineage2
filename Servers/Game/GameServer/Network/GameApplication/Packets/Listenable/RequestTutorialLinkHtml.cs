using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestTutorialLinkHtml
{
    public string Bypass;

    public RequestTutorialLinkHtml(Packet packet)
    {
        Bypass = packet.ReadString();
    }
}