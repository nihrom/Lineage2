using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestExSetPledgeCrestLarge
{
    public RequestExSetPledgeCrestLarge(Packet packet)
    {
        var _length = packet.ReadInt();
        if (_length > 2176)
        {
            return;
        }
		
        var _data = packet.ReadBytes(_length);
    }
}