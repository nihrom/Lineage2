using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestWriteHeroWords
{
    public RequestWriteHeroWords(Packet packet)
    {
        _heroWords = readString();
    }
}