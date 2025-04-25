using Common.Network;

namespace GameServer.Network.LoginServer.Packets.Sent;

public class _0x08_ReplyCharacters : Packet
{
    public _0x08_ReplyCharacters(
        string account,
        byte chars,
        List<long> timesToDelete) : base(0x08)
    {
        WriteString(account);
        WriteByte(chars);
        WriteByte((byte)timesToDelete.Count);
        
        foreach (var timeToDelete in timesToDelete)
            WriteLong(timeToDelete);
    }
}