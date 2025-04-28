using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class FinishRotating
{
    public FinishRotating(Packet packet)
    {
        var _degree = packet.ReadInt();
        packet.ReadInt(); // Unknown.
    }
}