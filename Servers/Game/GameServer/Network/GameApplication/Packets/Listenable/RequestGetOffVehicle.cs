using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestGetOffVehicle
{
    public RequestGetOffVehicle(Packet packet)
    {
        _boatId = readInt();
        _x = readInt();
        _y = readInt();
        _z = readInt();
    }
}