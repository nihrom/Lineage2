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
    
    public static Packet LoginFail(int reason)
    {
        byte opcode = 0x01;

        var p = new Packet(opcode);
        p.WriteInt(reason);

        return p;
    }
    
    public static Packet AuthResponse(byte serverId, string serverName)
    {
        byte opcode = 0x02;

        var p = new Packet(opcode);
        p.WriteByte(serverId);
        p.WriteString(serverName);

        return p;
    }

    public static Packet PlayerAuthResponse(string account, bool response)
    {
        byte opcode = 0x03;

        var p = new Packet(opcode);
        p.WriteString(account);
        p.WriteByte(response ? (byte)1 : (byte)0);

        return p;
    }

    public static Packet KickPlayer(string account)
    {
        byte opcode = 0x04;

        var p = new Packet(opcode);
        p.WriteString(account);

        return p;
    }

    public static Packet RequestCharacters(string account)
    {
        byte opcode = 0x05;

        var p = new Packet(opcode);
        p.WriteString(account);

        return p;
    }

    public static Packet ChangePasswordResponse(byte successful, string characterName, string msgToSend)
    {
        byte opcode = 0x06;
        
        var p = new Packet(opcode);
        // writeByte(successful); // 0 false, 1 true
        p.WriteString(characterName);
        p.WriteString(msgToSend);

        return p;
    }
}