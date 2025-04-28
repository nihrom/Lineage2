using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestSetAllyCrest
{
    public RequestSetAllyCrest(Packet packet)
    {
        var _length = packet.ReadInt();
        if (_length > 192)
        {
            return;
        }
        var _data = packet.ReadBytes(_length);
    }
}