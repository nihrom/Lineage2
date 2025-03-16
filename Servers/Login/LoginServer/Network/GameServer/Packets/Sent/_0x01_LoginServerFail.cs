using Common.Network;

namespace LoginServer.Network.GameServer.Packets.Sent;

public class _0x01_LoginServerFail : Packet
{
    public _0x01_LoginServerFail(byte reason) : base(0x01)
    {
        WriteByte(reason);
    }
}