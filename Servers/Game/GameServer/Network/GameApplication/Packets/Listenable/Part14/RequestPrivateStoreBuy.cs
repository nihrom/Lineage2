using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPrivateStoreBuy
{
    public int StorePlayerId;

    public RequestPrivateStoreBuy(Packet packet)
    {
        // StorePlayerId = packet.ReadInt();
        //
        //  int count = packet.ReadInt();
        //  
        // if ((count <= 0) || (count > Config.MAX_ITEM_IN_PACKET) || ((count * BATCH_LENGTH) != remaining()))
        // {
        //     return;
        // }
        //
        // _items = new HashSet<>();
        // for (int i = 0; i < count; i++)
        // {
        //      int objectId = packet.ReadInt();
        //     int cnt = packet.ReadInt();
        //     if (cnt > Integer.MAX_VALUE)
        //     {
        //         cnt = Integer.MAX_VALUE;
        //     }
        //      int price = packet.ReadInt();
        //     if ((objectId < 1) || (cnt < 1) || (price < 0))
        //     {
        //         _items = null;
        //         return;
        //     }
        //     
        //     _items.add(new ItemRequest(objectId, cnt, price));
        // }
    }
}