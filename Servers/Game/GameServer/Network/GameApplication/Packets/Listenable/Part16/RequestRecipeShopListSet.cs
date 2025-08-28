using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestRecipeShopListSet
{
    public RequestRecipeShopListSet(Packet packet)
    {
        //  int count = packet.ReadInt();
        // if ((count <= 0) || (count > Config.MAX_ITEM_IN_PACKET) || ((count * BATCH_LENGTH) != remaining()))
        // {
        //     return;
        // }
        //
        // _items = new ManufactureItem[count];
        // for (int i = 0; i < count; i++)
        // {
        //      int id = packet.ReadInt();
        //      int cost = packet.ReadInt();
        //     if (cost < 0)
        //     {
        //         _items = null;
        //         return;
        //     }
        //     _items[i] = new ManufactureItem(id, cost);
        // }
    }
}