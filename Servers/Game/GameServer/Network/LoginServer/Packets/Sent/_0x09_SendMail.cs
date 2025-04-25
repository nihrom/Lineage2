using Common.Network;

namespace GameServer.Network.LoginServer.Packets.Sent;

public class _0x09_SendMail : Packet
{
    public _0x09_SendMail(
        string accountName,
        string mailId,
        List<string> args) : base(0x09)
    {
        WriteString(accountName);
        WriteString(mailId);
        WriteByte((byte)args.Count);
        
        foreach (var arg in args)
        {
            WriteString(arg);
        }
    }
}