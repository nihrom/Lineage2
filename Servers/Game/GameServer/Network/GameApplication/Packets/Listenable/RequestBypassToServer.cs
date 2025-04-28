using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestBypassToServer
{
    public string Command;

    public RequestBypassToServer(Packet packet)
    {
        Command = packet.ReadString();
    }
}