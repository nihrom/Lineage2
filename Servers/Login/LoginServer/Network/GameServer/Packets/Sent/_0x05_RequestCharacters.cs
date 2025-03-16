using Common.Network;

namespace LoginServer.Network.GameServer.Packets.Sent;

public class _0x05_RequestCharacters : Packet
{
    public _0x05_RequestCharacters(string account) : base(0x05)
    {
        WriteString(account);
    }
}