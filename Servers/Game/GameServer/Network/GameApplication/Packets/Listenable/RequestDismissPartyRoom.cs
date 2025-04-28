using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestDismissPartyRoom
{
    public RequestDismissPartyRoom(Packet packet)
    {
        var _roomid = packet.ReadInt();
        var _data2 = packet.ReadInt();
    }
}