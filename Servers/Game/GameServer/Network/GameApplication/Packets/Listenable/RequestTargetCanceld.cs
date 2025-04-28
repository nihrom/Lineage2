using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestTargetCanceld
{
    public RequestTargetCanceld(Packet packet)
    {
        var _unselect = packet.ReadShort();
    }
}