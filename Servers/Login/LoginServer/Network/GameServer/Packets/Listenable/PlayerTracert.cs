using Common.Network;

namespace LoginServer.Network.GameServer.Packets.Listenable;

public class PlayerTracert
{
    public PlayerTracert(Packet packet)
    {
        string account = packet.ReadString();
        string pcIp = packet.ReadString();
        string hop1 = packet.ReadString();
        string hop2 = packet.ReadString();
        string hop3 = packet.ReadString();
        string hop4 = packet.ReadString();
    }
}