using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class ValidatePosition
{
    public ValidatePosition(Packet packet)
    {
        _x = readInt();
        _y = readInt();
        _z = readInt();
        _heading = readInt();
        readInt(); // vehicle id
    }
}