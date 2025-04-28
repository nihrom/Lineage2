using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestExPledgeCrestLarge
{
    public RequestExPledgeCrestLarge(Packet packet)
    {
        _crestId = readInt();
    }
}