using Common.Network;

namespace LoginServer.Network.GameApplication.Packets.Sent;

public class _0x01_LoginFail : Packet
{
    public _0x01_LoginFail(byte reason) : base(0x01)
    {
        WriteByte(reason);
    }
}