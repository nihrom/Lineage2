using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestSetCrop
{
    public RequestSetCrop(Packet packet)
    {
        _manorId = readInt();
        final int count = readInt();
        if ((count <= 0) || (count > Config.MAX_ITEM_IN_PACKET) || ((count * BATCH_LENGTH) != remaining()))
        {
            return;
        }
		
        _items = new ArrayList<>(count);
        for (int i = 0; i < count; i++)
        {
            final int itemId = readInt();
            final int sales = readInt();
            final int price = readInt();
            final int type = readByte();
            if ((itemId < 1) || (sales < 0) || (price < 0))
            {
                _items.clear();
                return;
            }
			
            if (sales > 0)
            {
                _items.add(new CropProcure(itemId, sales, type, sales, price));
            }
        }
    }
}