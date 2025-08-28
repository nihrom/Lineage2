using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestGetOffVehicle
{
    public int BoatId;
    public int X;
    public int Y;
    public int Z;

    public RequestGetOffVehicle(Packet packet)
    {
        BoatId = packet.ReadInt();
        X = packet.ReadInt();
        Y = packet.ReadInt();
        Z = packet.ReadInt();
    }
}