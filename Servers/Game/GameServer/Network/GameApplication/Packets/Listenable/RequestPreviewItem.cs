using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPreviewItem
{
    public int Unk;
    public int ListId;
    public int Count;

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
		
        // Create _items table that will contain all ItemID to Wear
        _items = new int[Count];
		
        // Fill _items table with all ItemID to Wear
        for (int i = 0; i < Count; i++)
        {
            _items[i] = packet.ReadInt();
        }
    }
}