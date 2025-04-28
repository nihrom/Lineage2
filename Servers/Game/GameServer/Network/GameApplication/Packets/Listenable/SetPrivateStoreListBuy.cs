using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class SetPrivateStoreListBuy
{
    public SetPrivateStoreListBuy(Packet packet)
    {
        final int count = readInt();
        if ((count < 1) || (count > Config.MAX_ITEM_IN_PACKET) || ((count * BATCH_LENGTH) > remaining()))
        {
            return;
        }
		
        _items = new Item[count];
        for (int i = 0; i < count; i++)
        {
            final int itemId = readInt();
            readShort(); // Enchant?
            readShort(); // TODO analyse this
			
            final int cnt = readInt();
            final int price = readInt();
            if ((cnt > Integer.MAX_VALUE) || (itemId < 1) || (cnt < 1) || (price < 0))
            {
                _items = null;
                return;
            }
			
            _items[i] = new Item(itemId, cnt, price);
        }
    }
}