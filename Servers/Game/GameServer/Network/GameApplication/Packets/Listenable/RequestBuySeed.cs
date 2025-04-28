using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestBuySeed
{
    public RequestBuySeed(Packet packet)
    {
        // _manorId = readInt();
        // final int count = readInt();
        // if ((count <= 0) || (count > Config.MAX_ITEM_IN_PACKET) || ((count * BATCH_LENGTH) != remaining()))
        // {
        //     return;
        // }
		      //
        // _items = new ArrayList<>(count);
        // for (int i = 0; i < count; i++)
        // {
        //     final int itemId = readInt();
        //     final int cnt = readInt();
        //     if ((cnt > Integer.MAX_VALUE) || (cnt < 1) || (itemId < 1))
        //     {
        //         _items = null;
        //         return;
        //     }
        //     _items.add(new ItemHolder(itemId, cnt));
        // }
    }
}