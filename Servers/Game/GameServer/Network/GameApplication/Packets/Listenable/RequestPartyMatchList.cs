using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPartyMatchList
{
    public RequestPartyMatchList(Packet packet)
    {
        _roomid = readInt();
        _membersmax = readInt();
        _minLevel = readInt();
        _maxLevel = readInt();
        _loot = readInt();
        _roomtitle = readString();
    }
}