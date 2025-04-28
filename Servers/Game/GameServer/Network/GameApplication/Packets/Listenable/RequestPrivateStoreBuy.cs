using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPrivateStoreBuy
{
    public RequestPrivateStoreBuy(Packet packet)
    {
        _storePlayerId = readInt();
        final int count = readInt();
        if ((count <= 0) || (count > Config.MAX_ITEM_IN_PACKET) || ((count * BATCH_LENGTH) != remaining()))
        {
            return;
        }
		
        _items = new HashSet<>();
        for (int i = 0; i < count; i++)
        {
            final int objectId = readInt();
            int cnt = readInt();
            if (cnt > Integer.MAX_VALUE)
            {
                cnt = Integer.MAX_VALUE;
            }
            final int price = readInt();
            if ((objectId < 1) || (cnt < 1) || (price < 0))
            {
                _items = null;
                return;
            }
			
            _items.add(new ItemRequest(objectId, cnt, price));
        }
    }
}