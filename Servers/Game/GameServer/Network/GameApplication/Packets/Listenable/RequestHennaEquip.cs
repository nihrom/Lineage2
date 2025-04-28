using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestHennaEquip
{
    public RequestHennaEquip(Packet packet)
    {
        _symbolId = readInt();
    }
}