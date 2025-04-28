using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPackageSend
{
    public RequestPackageSend(Packet packet)
    {
        _objectId = readInt();
		
        final int count = readInt();
        if ((count <= 0) || (count > Config.MAX_ITEM_IN_PACKET) || ((count * BATCH_LENGTH) != remaining()))
        {
            _items = null;
            return;
        }
		
        _items = new ItemHolder[count];
        for (int i = 0; i < count; i++)
        {
            final int objId = readInt();
            final int cnt = readInt();
            if ((objId < 1) || (cnt < 0))
            {
                _items = null;
                return;
            }
			
            _items[i] = new ItemHolder(objId, cnt);
        }
    }
}