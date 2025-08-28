using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class SendWareHouseDepositList
{
    public SendWareHouseDepositList(Packet packet)
    {
        //  int size = packet.ReadInt();
        // if ((size <= 0) || (size > Config.MAX_ITEM_IN_PACKET) || ((size * BATCH_LENGTH) != remaining()))
        // {
        //     return;
        // }
        //
        // _items = new ArrayList<>(size);
        // for (int i = 0; i < size; i++)
        // {
        //      int objId = packet.ReadInt();
        //      int count = packet.ReadInt();
        //     if ((count > Integer.MAX_VALUE) || (objId < 1) || (count < 1))
        //     {
        //         _items = null;
        //         return;
        //     }
        //     _items.add(new ItemHolder(objId, count));
        // }
    }
}