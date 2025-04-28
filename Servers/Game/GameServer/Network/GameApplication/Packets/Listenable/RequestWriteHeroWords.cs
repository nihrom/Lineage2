using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestWriteHeroWords
{
    public RequestWriteHeroWords(Packet packet)
    {
        var _heroWords = packet.ReadString();
    }
}