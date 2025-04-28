using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestSetPledgeCrest
{
    public RequestSetPledgeCrest(Packet packet)
    {
        var _length = packet.ReadInt();
        if (_length > 256)
        {
            return;
        }
		
        var _data = packet.ReadBytes(_length);
    }
}