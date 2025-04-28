using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestListPartyMatchingWaitingRoom
{
    public RequestListPartyMatchingWaitingRoom(Packet packet)
    {
        _page = readInt();
        _minLevel = readInt();
        _maxLevel = readInt();
        _mode = readInt();
    }
}