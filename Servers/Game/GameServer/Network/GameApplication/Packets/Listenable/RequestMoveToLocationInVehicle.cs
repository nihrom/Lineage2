using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestMoveToLocationInVehicle
{
    public RequestMoveToLocationInVehicle(Packet packet)
    {
        _boatId = readInt(); // objectId of boat
        _targetX = readInt();
        _targetY = readInt();
        _targetZ = readInt();
        _originX = readInt();
        _originY = readInt();
        _originZ = readInt();
    }
}