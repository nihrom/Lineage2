using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPledgeWarList
{
    public RequestPledgeWarList(Packet packet)
    {
        _unk1 = readInt();
        _tab = readInt();
    }
}