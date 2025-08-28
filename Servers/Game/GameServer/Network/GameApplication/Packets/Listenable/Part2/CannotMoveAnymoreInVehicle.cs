using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class CannotMoveAnymoreInVehicle
{
    public int BoatId;
    public int X;
    public int Y;
    public int Z;
    public int Heading;

    public CannotMoveAnymoreInVehicle(Packet packet)
    {
        BoatId = packet.ReadInt();
        X = packet.ReadInt();
        Y = packet.ReadInt();
        Z = packet.ReadInt();
        Heading = packet.ReadInt();
    }
}