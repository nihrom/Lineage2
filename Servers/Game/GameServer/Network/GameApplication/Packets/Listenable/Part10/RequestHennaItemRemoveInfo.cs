using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part10;

public class RequestHennaItemRemoveInfo
{
    public int SymbolId;

    public RequestHennaItemRemoveInfo(Packet packet)
    {
        SymbolId = packet.ReadInt();
    }
}