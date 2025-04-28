using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class StartRotating
{
    public StartRotating(Packet packet)
    {
        _degree = readInt();
        _side = readInt();
    }
}