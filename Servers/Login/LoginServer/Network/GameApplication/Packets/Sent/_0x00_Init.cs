using Common.Network;

namespace LoginServer.Network.GameApplication.Packets.Sent;

public class _0x00_Init : Packet
{
    private const int ProtocolRevision1 = 0x0000c621;

    public _0x00_Init(int sessionId, byte[] publicKey, byte[] blowfishKey) : base(0x00)
    {
        WriteInt(sessionId, ProtocolRevision1);
        WriteByteArray(publicKey); // RSA Public Key
        WriteInt(0x29DD954E, 0x77C39CFC, unchecked((int)0x97ADB620), 0x07BDE0F7); // unk GG related?
        WriteByteArray(blowfishKey);
        WriteByte(0); // null termination
    }
}