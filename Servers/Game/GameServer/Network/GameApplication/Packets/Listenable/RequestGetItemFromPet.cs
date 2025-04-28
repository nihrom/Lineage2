using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestGetItemFromPet
{
    public RequestGetItemFromPet(Packet packet)
    {
        _objectId = readInt();
        _amount = readInt();
        _unknown = readInt(); // = 0 for most trades
    }
}