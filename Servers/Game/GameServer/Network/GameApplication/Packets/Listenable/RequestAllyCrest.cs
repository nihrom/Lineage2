using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestAllyCrest
{
    public RequestAllyCrest(Packet packet)
    {
        var _crestId = packet.ReadInt();
    }
}