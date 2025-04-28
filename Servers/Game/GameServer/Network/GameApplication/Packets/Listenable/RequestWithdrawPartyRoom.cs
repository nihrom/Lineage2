using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestWithdrawPartyRoom
{
    public RequestWithdrawPartyRoom(Packet packet)
    {
        _roomid = readInt();
        _unk1 = readInt();
    }
}