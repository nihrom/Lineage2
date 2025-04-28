using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestExSetPledgeCrestLarge
{
    public RequestExSetPledgeCrestLarge(Packet packet)
    {
        _length = readInt();
        if (_length > 2176)
        {
            return;
        }
		
        _data = readBytes(_length);
    }
}