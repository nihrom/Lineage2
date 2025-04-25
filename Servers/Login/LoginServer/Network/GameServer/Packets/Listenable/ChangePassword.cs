using Common.Network;

namespace LoginServer.Network.GameServer.Packets.Listenable;

public class ChangePassword
{
    public ChangePassword(Packet packet)
    {
        string accountName = packet.ReadString();
        string characterName = packet.ReadString();
        string currentPassword = packet.ReadString();
        string newPassword = packet.ReadString();
    }
}