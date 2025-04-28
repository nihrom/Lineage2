using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestSSQStatus
{
    public RequestSSQStatus(Packet packet)
    {
        _page = readByte();
    }
}