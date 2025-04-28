using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class CannotMoveAnymore
{
    public CannotMoveAnymore(Packet packet)
    {
        var _x = packet.ReadInt();
        var _y = packet.ReadInt();
        var _z = packet.ReadInt();
        var _heading = packet.ReadInt();
    }
}