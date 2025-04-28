using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestGiveItemToPet
{
    public RequestGiveItemToPet(Packet packet)
    {
        _objectId = readInt();
        _amount = readInt();
    }
}