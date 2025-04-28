using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestExPledgeCrestLarge
{
    public RequestExPledgeCrestLarge(Packet packet)
    {
        var _crestId = packet.ReadInt();
    }
}