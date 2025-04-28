using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestHennaItemRemoveInfo
{
    public RequestHennaItemRemoveInfo(Packet packet)
    {
        var _symbolId = packet.ReadInt();
    }
}