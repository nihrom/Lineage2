using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestSetAllyCrest
{
    public RequestSetAllyCrest(Packet packet)
    {
        _length = readInt();
        if (_length > 192)
        {
            return;
        }
        _data = readBytes(_length);
    }
}