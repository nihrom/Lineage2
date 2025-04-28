using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPartyMatchDetail
{
    public RequestPartyMatchDetail(Packet packet)
    {
        var _roomid = packet.ReadInt();
        // If player click on Room all unk are 0
        // If player click AutoJoin values are -1 1 1
        var _unk1 = packet.ReadInt();
        var _unk2 = packet.ReadInt();
        var _unk3 = packet.ReadInt();
    }
}