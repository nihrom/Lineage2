using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPartyMatchDetail
{
    public RequestPartyMatchDetail(Packet packet)
    {
        _roomid = readInt();
        // If player click on Room all unk are 0
        // If player click AutoJoin values are -1 1 1
        _unk1 = readInt();
        _unk2 = readInt();
        _unk3 = readInt();
    }
}