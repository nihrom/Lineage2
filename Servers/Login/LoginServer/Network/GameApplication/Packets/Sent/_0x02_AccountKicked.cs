using Common.Network;

namespace LoginServer.Network.GameApplication.Packets.Sent;

public class _0x02_AccountKicked : Packet
{
    public _0x02_AccountKicked(int reason) : base(0x02)
    {
        WriteInt(reason);
    }
}