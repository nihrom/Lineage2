using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestHennaItemInfo
{
    public int SymbolId;

    public RequestHennaItemInfo(Packet packet)
    {
        SymbolId = packet.ReadInt();
    }
}