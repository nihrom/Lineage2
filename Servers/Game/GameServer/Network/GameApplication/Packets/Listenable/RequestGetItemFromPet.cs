using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestGetItemFromPet
{
    public RequestGetItemFromPet(Packet packet)
    {
        var _objectId = packet.ReadInt();
        var _amount = packet.ReadInt();
        var _unknown = packet.ReadInt(); // = 0 for most trades
    }
}