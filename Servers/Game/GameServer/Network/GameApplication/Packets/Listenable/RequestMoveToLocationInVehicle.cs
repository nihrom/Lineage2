using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestMoveToLocationInVehicle
{
    public int BoatId;
    public int TargetX;
    public int TargetY;
    public int TargetZ;
    public int OriginX;
    public int OriginY;
    public int OriginZ;

    public RequestMoveToLocationInVehicle(Packet packet)
    {
        BoatId = packet.ReadInt();
        TargetX = packet.ReadInt();
        TargetY = packet.ReadInt();
        TargetZ = packet.ReadInt();
        OriginX = packet.ReadInt();
        OriginY = packet.ReadInt();
        OriginZ = packet.ReadInt();
    }
}