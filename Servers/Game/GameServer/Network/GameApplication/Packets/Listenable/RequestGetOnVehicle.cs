using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestGetOnVehicle
{
    public RequestGetOnVehicle(Packet packet)
    {
        _boatId = readInt();
        _pos = new Location(readInt(), readInt(), readInt());
    }
}