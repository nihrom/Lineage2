using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part20;

public class RequestWriteHeroWords
{
    public string HeroWords;

    public RequestWriteHeroWords(Packet packet)
    {
        HeroWords = packet.ReadString();
    }
}