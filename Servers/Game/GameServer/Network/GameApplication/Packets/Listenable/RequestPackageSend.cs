using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPackageSend
{
    public int ObjectId;

    public RequestPackageSend(Packet packet)
    {
        ObjectId = packet.ReadInt();
		
         int count = packet.ReadInt();
        if ((count <= 0) || (count > Config.MAX_ITEM_IN_PACKET) || ((count * BATCH_LENGTH) != remaining()))
        {
            _items = null;
            return;
        }
		
        _items = new ItemHolder[count];
        for (int i = 0; i < count; i++)
        {
             int objId = packet.ReadInt();
             int cnt = packet.ReadInt();
            if ((objId < 1) || (cnt < 0))
            {
                _items = null;
                return;
            }
			
            _items[i] = new ItemHolder(objId, cnt);
        }
    }
}