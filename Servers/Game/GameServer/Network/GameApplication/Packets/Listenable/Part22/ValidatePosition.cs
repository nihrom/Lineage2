using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class ValidatePosition
{
    public int X;
    public int Y;
    public int Z;
    public int Heading;

    public ValidatePosition(Packet packet)
    {
        X = packet.ReadInt();
        Y = packet.ReadInt();
        Z = packet.ReadInt();
        Heading = packet.ReadInt();
        packet.ReadInt(); // vehicle id
    }
}