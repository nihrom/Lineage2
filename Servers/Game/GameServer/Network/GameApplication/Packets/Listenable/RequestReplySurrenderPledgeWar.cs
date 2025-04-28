using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestReplySurrenderPledgeWar
{
    public RequestReplySurrenderPledgeWar(Packet packet)
    {
        var _reqName = packet.ReadString();
        var _answer = packet.ReadInt();
    }
}