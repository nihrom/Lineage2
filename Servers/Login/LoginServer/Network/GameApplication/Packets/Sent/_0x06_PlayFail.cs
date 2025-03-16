using Common.Network;

namespace LoginServer.Network.GameApplication.Packets.Sent;

public class _0x06_PlayFail : Packet
{
    public _0x06_PlayFail(byte reason) : base(0x06)
    {
        WriteByte(reason);
    }
}