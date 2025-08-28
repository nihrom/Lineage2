using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestOustFromPartyRoom
{
    public int Charid;

    public RequestOustFromPartyRoom(Packet packet)
    {
        Charid = packet.ReadInt();
    }
}