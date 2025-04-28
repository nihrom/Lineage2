using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestGetOnVehicle
{
    public RequestGetOnVehicle(Packet packet)
    {
        var _boatId = packet.ReadInt();
        var _pos = new Location(packet.ReadInt(), packet.ReadInt(), packet.ReadInt());
    }
}