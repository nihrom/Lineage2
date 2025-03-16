using Common.Network;

namespace LoginServer.Network.GameApplication.Packets.Sent;

public class _0x0b_GGAuth : Packet
{
    public _0x0b_GGAuth(int sessionId) : base(0x0b)
    {
        WriteInt(sessionId);
        WriteByteArray(new byte[4]);
    }
}