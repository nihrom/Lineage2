using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestHennaItemInfo
{
    public RequestHennaItemInfo(Packet packet)
    {
        var _symbolId = packet.ReadInt();
    }
}