using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestHennaRemove
{
    public RequestHennaRemove(Packet packet)
    {
        _symbolId = readInt();
    }
}