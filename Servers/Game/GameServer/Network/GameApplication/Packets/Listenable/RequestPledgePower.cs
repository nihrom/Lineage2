using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPledgePower
{
    public RequestPledgePower(Packet packet)
    {
        var _rank = packet.ReadInt();
        var _action = packet.ReadInt();
        if (_action == 2)
        {
            var _privs = packet.ReadInt();
        }
        else
        {
            _privs = 0;
        }
    }
}