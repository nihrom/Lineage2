using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestSaveInventoryOrder
{
    public RequestSaveInventoryOrder(Packet packet)
    {
        int sz = packet.ReadInt();
        sz = Math.min(sz, LIMIT);
        _order = new ArrayList<>(sz);
        for (int i = 0; i < sz; i++)
        {
             int objectId = packet.ReadInt();
             int order = packet.ReadInt();
            _order.add(new InventoryOrder(objectId, order));
        }
    }
}