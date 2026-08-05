using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part5;

public class RequestBypassToServer
{
    public string Command;

    public RequestBypassToServer(Packet packet)
    {
        Command = packet.ReadString();
    }
}