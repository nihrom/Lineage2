using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestMoveToLocationInVehicle
{
    public RequestMoveToLocationInVehicle(Packet packet)
    {
        var _boatId = packet.ReadInt(); // objectId of boat
        var _targetX = packet.ReadInt();
        var _targetY = packet.ReadInt();
        var _targetZ = packet.ReadInt();
        var _originX = packet.ReadInt();
        var _originY = packet.ReadInt();
        var _originZ = packet.ReadInt();
    }
}