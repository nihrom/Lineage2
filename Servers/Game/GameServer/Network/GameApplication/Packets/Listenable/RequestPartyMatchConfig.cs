using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPartyMatchConfig
{
    public RequestPartyMatchConfig(Packet packet)
    {
        var _auto = packet.ReadInt(); //
        var _loc = packet.ReadInt(); // Location
        var _level = packet.ReadInt(); // my level
    }
}