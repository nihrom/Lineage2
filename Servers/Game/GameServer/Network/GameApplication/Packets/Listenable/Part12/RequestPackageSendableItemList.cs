using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPackageSendableItemList
{
    public int ObjectId;

    public RequestPackageSendableItemList(Packet packet)
    {
        ObjectId = packet.ReadInt();
    }
}