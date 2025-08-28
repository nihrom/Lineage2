using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class MoveWithDelta
{
    public MoveWithDelta(Packet packet)
    {
        packet.ReadInt(); // dx
        packet.ReadInt(); // dy
        packet.ReadInt(); // dz
    }
}