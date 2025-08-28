using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestGetOnVehicle
{
    public int BoatId;

    public RequestGetOnVehicle(Packet packet)
    {
        BoatId = packet.ReadInt();
        var _pos = new Location(packet.ReadInt(), packet.ReadInt(), packet.ReadInt());
    }
}