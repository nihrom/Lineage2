using Common.Network;

namespace LoginServer;

public static class PacketBuilder
{
    public static Packet Init(int sessionId, byte[] scrambledModulus, byte[] blowfishKey)
    {
        byte opcode = 0x00;
        var protocolRevision = 0x0000c621;
        var p = new Packet(opcode);
        p.WriteInt(sessionId, protocolRevision);
        p.WriteByteArray(scrambledModulus);
        p.WriteInt(0x29DD954E, 0x77C39CFC, unchecked((int)0x97ADB620), 0x07BDE0F7); // unk GG related?
        p.WriteByteArray(blowfishKey);
        p.WriteByte(0);
        return p;
    }
}