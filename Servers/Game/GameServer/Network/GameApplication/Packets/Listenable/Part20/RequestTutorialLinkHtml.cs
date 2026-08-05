using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part20;

public class RequestTutorialLinkHtml
{
    public string Bypass;

    public RequestTutorialLinkHtml(Packet packet)
    {
        Bypass = packet.ReadString();
    }
}