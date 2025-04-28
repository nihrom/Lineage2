using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPartyMatchList
{
    public RequestPartyMatchList(Packet packet)
    {
        var _roomid = packet.ReadInt();
        var _membersmax = packet.ReadInt();
        var _minLevel = packet.ReadInt();
        var _maxLevel = packet.ReadInt();
        var _loot = packet.ReadInt();
        var _roomtitle = packet.ReadString();
    }
}