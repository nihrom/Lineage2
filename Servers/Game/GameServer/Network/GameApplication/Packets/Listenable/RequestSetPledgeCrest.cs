using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestSetPledgeCrest
{
    public RequestSetPledgeCrest(Packet packet)
    {
        _length = readInt();
        if (_length > 256)
        {
            return;
        }
		
        _data = readBytes(_length);
    }
}