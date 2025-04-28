using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPrivateStoreSell
{
    public RequestPrivateStoreSell(Packet packet)
    {
        _storePlayerId = readInt();
        final int count = readInt();
        if ((count <= 0) || (count > Config.MAX_ITEM_IN_PACKET) || ((count * BATCH_LENGTH) != remaining()))
        {
            return;
        }
		
        _items = new ItemRequest[count];
        for (int i = 0; i < count; i++)
        {
            final int objectId = readInt();
            final int itemId = readInt();
            readShort(); // TODO analyse this
            readShort(); // TODO analyse this
            final int cnt = readInt();
            final int price = readInt();
            if ((count > Integer.MAX_VALUE) || (objectId < 1) || (itemId < 1) || (cnt < 1) || (price < 0))
            {
                _items = null;
                return;
            }
            _items[i] = new ItemRequest(objectId, itemId, cnt, price);
        }
    }
}