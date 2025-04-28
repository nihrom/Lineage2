using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class SetPrivateStoreListBuy
{
    public SetPrivateStoreListBuy(Packet packet)
    {
         int count = packet.ReadInt();
        if ((count < 1) || (count > Config.MAX_ITEM_IN_PACKET) || ((count * BATCH_LENGTH) > remaining()))
        {
            return;
        }
		
        _items = new Item[count];
        for (int i = 0; i < count; i++)
        {
             int itemId = packet.ReadInt();
            packet.ReadShort(); // Enchant?
            packet.ReadShort(); // TODO analyse this
			
             int cnt = packet.ReadInt();
             int price = packet.ReadInt();
            if ((cnt > Integer.MAX_VALUE) || (itemId < 1) || (cnt < 1) || (price < 0))
            {
                _items = null;
                return;
            }
			
            _items[i] = new Item(itemId, cnt, price);
        }
    }
}