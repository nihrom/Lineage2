using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPrivateStoreSell
{
    public int StorePlayerId;

    public RequestPrivateStoreSell(Packet packet)
    {
        // StorePlayerId = packet.ReadInt();
        //  int count = packet.ReadInt();
        // if ((count <= 0) || (count > Config.MAX_ITEM_IN_PACKET) || ((count * BATCH_LENGTH) != remaining()))
        // {
        //     return;
        // }
        //
        // _items = new ItemRequest[count];
        // for (int i = 0; i < count; i++)
        // {
        //      int objectId = packet.ReadInt();
        //      int itemId = packet.ReadInt();
        //     readShort(); // TODO analyse this
        //     readShort(); // TODO analyse this
        //      int cnt = packet.ReadInt();
        //      int price = packet.ReadInt();
        //     if ((count > Integer.MAX_VALUE) || (objectId < 1) || (itemId < 1) || (cnt < 1) || (price < 0))
        //     {
        //         _items = null;
        //         return;
        //     }
        //     _items[i] = new ItemRequest(objectId, itemId, cnt, price);
        // }
    }
}