using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestBuyItem
{
    public RequestBuyItem(Packet packet)
    {
        // _listId = readInt();
        // final int size = readInt();
        // if ((size <= 0) || (size > Config.MAX_ITEM_IN_PACKET) || ((size * BATCH_LENGTH) != remaining()))
        // {
        //     return;
        // }
		      //
        // _items = new ArrayList<>(size);
        // for (int i = 0; i < size; i++)
        // {
        //     final int itemId = readInt();
        //     final int count = readInt();
        //     if ((count > Integer.MAX_VALUE) || (itemId < 1) || (count < 1))
        //     {
        //         _items = null;
        //         return;
        //     }
			     //
        //     if (count > 10000) // Count check.
        //     {
        //         _items = null;
        //         return;
        //     }
			     //
        //     _items.add(new ItemHolder(itemId, count));
        // }
    }
}