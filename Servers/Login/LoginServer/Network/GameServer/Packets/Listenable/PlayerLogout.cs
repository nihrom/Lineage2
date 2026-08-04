using Common.Network;

namespace LoginServer.Network.GameServer.Packets.Listenable;

public class PlayerLogout
{
    public string Account { get; }

    public PlayerLogout(Packet packet)
    {
        Account = packet.ReadString();
    }
}