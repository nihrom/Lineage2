using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPreviewItem
{
    public int Unk;
    public int ListId;
    public int Count;
    public int[] Items;

    public RequestPreviewItem(Packet packet)
    {
        Unk = packet.ReadInt();
        ListId = packet.ReadInt();
        Count = packet.ReadInt();
        
        if (Count < 0)
        {
            Count = 0;
        }
        if (Count > 100)
        {
            return; // prevent too long lists
        }
        
        // Create Items table that will contain all ItemID to Wear
        Items = new int[Count];
        
        // Fill Items table with all ItemID to Wear
        for (int i = 0; i < Count; i++)
        {
            Items[i] = packet.ReadInt();
        }
    }
}