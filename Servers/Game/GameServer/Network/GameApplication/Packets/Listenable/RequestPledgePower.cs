using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPledgePower
{
    public RequestPledgePower(Packet packet)
    {
        _rank = readInt();
        _action = readInt();
        if (_action == 2)
        {
            _privs = readInt();
        }
        else
        {
            _privs = 0;
        }
    }
}