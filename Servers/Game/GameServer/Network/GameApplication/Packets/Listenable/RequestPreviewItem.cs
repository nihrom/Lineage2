using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPreviewItem
{
    public RequestPreviewItem(Packet packet)
    {
        _unk = readInt();
        _listId = readInt();
        _count = readInt();
        if (_count < 0)
        {
            _count = 0;
        }
        if (_count > 100)
        {
            return; // prevent too long lists
        }
		
        // Create _items table that will contain all ItemID to Wear
        _items = new int[_count];
		
        // Fill _items table with all ItemID to Wear
        for (int i = 0; i < _count; i++)
        {
            _items[i] = readInt();
        }
    }
}