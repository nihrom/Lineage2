using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class CannotMoveAnymoreInVehicle
{
    public CannotMoveAnymoreInVehicle(Packet packet)
    {
        var _boatId = packet.ReadInt();
        var _x = packet.ReadInt();
        var _y = packet.ReadInt();
        var _z = packet.ReadInt();
        var _heading = packet.ReadInt();
    }
}