using Common.Network;

namespace GameServer.Network.LoginServer.Packets.Sent;

public class _0x0B_ChangePassword : Packet
{
    public _0x0B_ChangePassword(
        string accountName,
        string characterName,
        string oldPass,
        string newPass) : base(0x0B)
    {
        WriteString(accountName);
        WriteString(characterName);
        WriteString(oldPass);
        WriteString(newPass);
    }
}