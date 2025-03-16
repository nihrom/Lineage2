using Common.Network;

namespace LoginServer.Network.GameServer.Packets.Sent;

public class _0x04_KickPlayer : Packet
{
    public _0x04_KickPlayer(string account) : base(0x04)
    {
        WriteString(account);
    }
}