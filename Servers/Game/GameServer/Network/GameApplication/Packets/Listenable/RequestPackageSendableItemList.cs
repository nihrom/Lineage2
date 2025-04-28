using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPackageSendableItemList
{
    public RequestPackageSendableItemList(Packet packet)
    {
        _objectId = readInt();
    }
}