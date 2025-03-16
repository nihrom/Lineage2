using Common.Network;

namespace LoginServer.Network.GameApplication.Packets.Sent;

public class _0x07_PlayOk : Packet
{
    public _0x07_PlayOk(int playOk1, int playOk2) : base(0x07)
    {
        WriteByte(0x07);
        WriteInt(playOk1);
        WriteInt(playOk2);
    }
}