using Common.Network;

namespace LoginServer.Network.GameServer.Packets.Listenable;

public class ChangeAccessLevel
{
    public ChangeAccessLevel(Packet packet)
    {
        int level = packet.ReadInt();
        string account = packet.ReadString();
    }
}