using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestOustFromPartyRoom
{
    public RequestOustFromPartyRoom(Packet packet)
    {
        var _charid = packet.ReadInt();
    }
}