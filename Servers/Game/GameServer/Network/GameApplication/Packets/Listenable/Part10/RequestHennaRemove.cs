using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestHennaRemove
{
    public int SymbolId;

    public RequestHennaRemove(Packet packet)
    {
        SymbolId = packet.ReadInt();
    }
}