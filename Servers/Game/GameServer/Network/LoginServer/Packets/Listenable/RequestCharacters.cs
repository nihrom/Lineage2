using Common.Network;

namespace GameServer.Network.LoginServer.Packets.Listenable;

public class RequestCharacters
{
    public string Account { get; }

    public RequestCharacters(Packet packet)
    {
        Account = packet.ReadString();
    }
}