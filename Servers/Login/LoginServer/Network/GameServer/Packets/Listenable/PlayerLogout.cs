using Common.Network;

namespace LoginServer.Network.GameServer.Packets.Listenable;

public class PlayerLogout
{
    public PlayerLogout(Packet packet)
    {
        string account = packet.ReadString();
    }
}