using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestConfirmCancelItem
{
    public RequestConfirmCancelItem(Packet packet)
    {
        var _objectId = packet.ReadInt();
    }
}