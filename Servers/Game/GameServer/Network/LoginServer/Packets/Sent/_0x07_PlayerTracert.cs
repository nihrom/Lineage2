using Common.Network;

namespace GameServer.Network.LoginServer.Packets.Sent;

public class _0x07_PlayerTracert : Packet
{
    public _0x07_PlayerTracert(
        string account,
        string pcIp,
        string hop1,
        string hop2,
        string hop3,
        string hop4) : base(0x07)
    {
        WriteString(account);
        WriteString(pcIp);
        WriteString(hop1);
        WriteString(hop2);
        WriteString(hop3);
        WriteString(hop4);
    }
}