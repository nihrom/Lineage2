using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPartyMatchConfig
{
    public RequestPartyMatchConfig(Packet packet)
    {
        _auto = readInt(); //
        _loc = readInt(); // Location
        _level = readInt(); // my level
    }
}