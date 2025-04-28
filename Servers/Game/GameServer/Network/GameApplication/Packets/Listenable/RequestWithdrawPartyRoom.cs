using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestWithdrawPartyRoom
{
    public RequestWithdrawPartyRoom(Packet packet)
    {
        var _roomid = packet.ReadInt();
        var _unk1 = packet.ReadInt();
    }
}