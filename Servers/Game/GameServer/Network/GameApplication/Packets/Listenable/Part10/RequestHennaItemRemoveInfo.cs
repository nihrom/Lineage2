using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestHennaItemRemoveInfo
{
    public int SymbolId;

    public RequestHennaItemRemoveInfo(Packet packet)
    {
        SymbolId = packet.ReadInt();
    }
}