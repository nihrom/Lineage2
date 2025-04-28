using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPledgeWarList
{
    public RequestPledgeWarList(Packet packet)
    {
        var _unk1 = packet.ReadInt();
        var _tab = packet.ReadInt();
    }
}