using Common.Network;

namespace LoginServer.Network.GameServer.Packets.Sent;

public class _0x03_PlayerAuthResponse : Packet
{
    public _0x03_PlayerAuthResponse(string account, bool response) : base(0x03)
    {
        WriteString(account);
        WriteByte(response ? (byte)1 : (byte)0);
    }
}