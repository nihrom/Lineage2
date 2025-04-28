using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestHennaEquip
{
    public int SymbolId;

    public RequestHennaEquip(Packet packet)
    {
        SymbolId = packet.ReadInt();
    }
}