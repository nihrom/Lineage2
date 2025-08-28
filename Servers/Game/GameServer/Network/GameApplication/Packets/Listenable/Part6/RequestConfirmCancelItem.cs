using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestConfirmCancelItem
{
    public int ObjectId;

    public RequestConfirmCancelItem(Packet packet)
    {
        ObjectId = packet.ReadInt();
    }
}