using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestProcureCropList
{
    public RequestProcureCropList(Packet packet)
    {
        //  int count = packet.ReadInt();
        // if ((count <= 0) || (count > Config.MAX_ITEM_IN_PACKET) || ((count * BATCH_LENGTH) != remaining()))
        // {
        //     return;
        // }
		      //
        // _items = new ArrayList<>(count);
        // for (int i = 0; i < count; i++)
        // {
        //      int objId = packet.ReadInt();
        //      int itemId = packet.ReadInt();
        //      int manorId = packet.ReadInt();
        //     int cnt = packet.ReadInt();
        //     if (cnt > Integer.MAX_VALUE)
        //     {
        //         cnt = Integer.MAX_VALUE;
        //     }
        //     if ((objId < 1) || (itemId < 1) || (manorId < 0) || (cnt < 0))
        //     {
        //         _items = null;
        //         return;
        //     }
        //     _items.add(new CropHolder(objId, itemId, cnt, manorId));
        // }
    }
}