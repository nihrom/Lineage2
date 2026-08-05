using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part21;

public class StartRotating
{
    public int Degree;
    public int Side;

    public StartRotating(Packet packet)
    {
        Degree = packet.ReadInt();
        Side = packet.ReadInt();
    }
}