using Common.Network;

namespace GameServer.Network.LoginServer.Packets.Sent;

public class _0x00_BlowFishKey : Packet
{
    public _0x00_BlowFishKey(byte[] encrypted) : base(0x00)
    {
        WriteInt(encrypted.Length);
        WriteByteArray(encrypted);
    }
}