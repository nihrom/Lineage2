using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestShortCutDel
{
    public RequestShortCutDel(Packet packet)
    {
        final int id = readInt();
        _slot = id % 12;
        _page = id / 12;
    }
}