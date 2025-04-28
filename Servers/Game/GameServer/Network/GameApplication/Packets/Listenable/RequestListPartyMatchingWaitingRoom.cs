using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestListPartyMatchingWaitingRoom
{
    public RequestListPartyMatchingWaitingRoom(Packet packet)
    {
        var _page = packet.ReadInt();
        var _minLevel = packet.ReadInt();
        var _maxLevel = packet.ReadInt();
        var _mode = packet.ReadInt();
    }
}