using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestSetSeed
{
    public RequestSetSeed(Packet packet)
    {
        var _manorId = packet.ReadInt();
         int count = packet.ReadInt();
        if ((count <= 0) || (count > Config.MAX_ITEM_IN_PACKET) || ((count * BATCH_LENGTH) != remaining()))
        {
            return;
        }
		
        _items = new ArrayList<>(count);
        for (int i = 0; i < count; i++)
        {
             int itemId = packet.ReadInt();
             int sales = packet.ReadInt();
             int price = packet.ReadInt();
            if ((itemId < 1) || (sales < 0) || (price < 0))
            {
                _items.clear();
                return;
            }
			
            if (sales > 0)
            {
                _items.add(new SeedProduction(itemId, sales, price, sales));
            }
        }
    }
}