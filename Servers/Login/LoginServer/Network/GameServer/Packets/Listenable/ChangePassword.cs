using Common.Network;

namespace LoginServer.Network.GameServer.Packets.Listenable;

public class ChangePassword
{
    public string AccountName { get; }
    
    public string CharacterName { get; }
    
    public string CurrentPassword { get; }
    
    public string NewPassword { get; }

    public ChangePassword(Packet packet)
    {
        AccountName = packet.ReadString();
        CharacterName = packet.ReadString();
        CurrentPassword = packet.ReadString();
        NewPassword = packet.ReadString();
    }
}