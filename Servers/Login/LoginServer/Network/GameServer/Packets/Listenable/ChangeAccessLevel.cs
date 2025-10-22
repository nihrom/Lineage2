using Common.Network;

namespace LoginServer.Network.GameServer.Packets.Listenable;

public class ChangeAccessLevel
{
    public int Level;
    public string Account;

    public ChangeAccessLevel(Packet packet)
    {
        Level = packet.ReadInt();
        Account = packet.ReadString();
    }
}