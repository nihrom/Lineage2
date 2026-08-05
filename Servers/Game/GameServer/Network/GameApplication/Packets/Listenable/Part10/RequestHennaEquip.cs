using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part10;

public class RequestHennaEquip
{
    public int SymbolId;

    public RequestHennaEquip(Packet packet)
    {
        SymbolId = packet.ReadInt();
    }
}