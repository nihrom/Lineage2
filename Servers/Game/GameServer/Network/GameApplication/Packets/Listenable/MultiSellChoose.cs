using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class MultiSellChoose
{
    public int ListId;
    public int EntryId;
    public int Amount;

    public MultiSellChoose(Packet packet)
    {
        ListId = packet.ReadInt();
        EntryId = packet.ReadInt();
        Amount = packet.ReadInt();
    }
}