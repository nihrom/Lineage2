using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestWriteHeroWords
{
    public string HeroWords;

    public RequestWriteHeroWords(Packet packet)
    {
        HeroWords = packet.ReadString();
    }
}