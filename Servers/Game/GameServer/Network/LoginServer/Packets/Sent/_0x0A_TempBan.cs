using Common.Network;

namespace GameServer.Network.LoginServer.Packets.Sent;

public class _0x0A_TempBan : Packet
{
    public _0x0A_TempBan(string accountName, string ip, long time) : base(0x0A)
    {
        WriteString(accountName);
        WriteString(ip);
        WriteLong(DateTime.UtcNow.Millisecond + (time * 60000));
        WriteByte(0x00);
    }
}