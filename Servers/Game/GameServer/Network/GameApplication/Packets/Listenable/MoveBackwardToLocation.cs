using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class MoveBackwardToLocation
{
    public MoveBackwardToLocation(Packet packet)
    {
        var _targetX = packet.ReadInt();
        var _targetY = packet.ReadInt();
        var _targetZ = packet.ReadInt();
        var _originX = packet.ReadInt();
        var _originY = packet.ReadInt();
        var _originZ = packet.ReadInt();
        var _movementMode = packet.ReadInt(); // is 0 if cursor keys are used 1 if mouse is used
    }
}