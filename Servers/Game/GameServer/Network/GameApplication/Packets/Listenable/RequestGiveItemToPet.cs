using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestGiveItemToPet
{
    public RequestGiveItemToPet(Packet packet)
    {
        var _objectId = packet.ReadInt();
        var _amount = packet.ReadInt();
    }
}