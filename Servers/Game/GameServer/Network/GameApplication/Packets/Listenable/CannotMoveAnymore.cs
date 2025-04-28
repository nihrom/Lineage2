using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class CannotMoveAnymore
{
    public int X;
    public int Y;
    public int Z;
    public int Heading;

    public CannotMoveAnymore(Packet packet)
    {
        X = packet.ReadInt();
        Y = packet.ReadInt();
        Z = packet.ReadInt();
        Heading = packet.ReadInt();
    }
}