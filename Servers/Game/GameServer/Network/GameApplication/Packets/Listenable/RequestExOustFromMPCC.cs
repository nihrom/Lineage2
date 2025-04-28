using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestExOustFromMPCC
{
    public RequestExOustFromMPCC(Packet packet)
    {
        var _name = packet.ReadString();
    }
}