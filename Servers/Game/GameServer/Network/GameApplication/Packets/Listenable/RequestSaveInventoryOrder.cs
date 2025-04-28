using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestSaveInventoryOrder
{
    public RequestSaveInventoryOrder(Packet packet)
    {
        int sz = readInt();
        sz = Math.min(sz, LIMIT);
        _order = new ArrayList<>(sz);
        for (int i = 0; i < sz; i++)
        {
            final int objectId = readInt();
            final int order = readInt();
            _order.add(new InventoryOrder(objectId, order));
        }
    }
}