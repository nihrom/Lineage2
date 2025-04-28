using Common.Network;

namespace GameServer.Network.LoginServer.Packets.Listenable;

public class KickPlayer
{
    public string Account { get; }

    public KickPlayer(Packet packet)
    {
        Account = packet.ReadString();
    }
}