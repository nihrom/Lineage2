using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestSellItem
{
    public RequestSellItem(Packet packet)
    {
        _listId = readInt();
        final int size = readInt();
        if ((size <= 0) || (size > Config.MAX_ITEM_IN_PACKET) || ((size * BATCH_LENGTH) != remaining()))
        {
            return;
        }
		
        _items = new ArrayList<>(size);
        for (int i = 0; i < size; i++)
        {
            final int objectId = readInt();
            final int itemId = readInt();
            final int count = readInt();
            if ((count > Integer.MAX_VALUE) || (objectId < 1) || (itemId < 1) || (count < 1))
            {
                _items = null;
                return;
            }
            _items.add(new UniqueItemHolder(itemId, objectId, count));
        }
    }
}