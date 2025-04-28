using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestGetOffVehicle
{
    public RequestGetOffVehicle(Packet packet)
    {
        var _boatId = packet.ReadInt();
        var _x = packet.ReadInt();
        var _y = packet.ReadInt();
        var _z = packet.ReadInt();
    }
}