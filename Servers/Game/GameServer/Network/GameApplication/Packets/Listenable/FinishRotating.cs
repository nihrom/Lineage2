using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class FinishRotating
{
    public int Degree;

    public FinishRotating(Packet packet)
    {
        Degree = packet.ReadInt();
        packet.ReadInt(); // Unknown.
    }
}