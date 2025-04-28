using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestBuyItem
{
    public RequestBuyItem(Packet packet)
    {
        var _listId = packet.ReadInt();
         int size = packet.ReadInt();
        if ((size <= 0) || (size > Config.MAX_ITEM_IN_PACKET) || ((size * BATCH_LENGTH) != remaining()))
        {
            return;
        }
		      
        _items = new ArrayList<>(size);
        for (int i = 0; i < size; i++)
        {
             int itemId = packet.ReadInt();
             int count = packet.ReadInt();
            if ((count > Integer.MAX_VALUE) || (itemId < 1) || (count < 1))
            {
                _items = null;
                return;
            }
			     
            if (count > 10000) // Count check.
            {
                _items = null;
                return;
            }
			     
            _items.add(new ItemHolder(itemId, count));
        }
    }
}