using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestBypassToServer
{
    public RequestBypassToServer(Packet packet)
    {
        var _command = packet.ReadString();
    }
}