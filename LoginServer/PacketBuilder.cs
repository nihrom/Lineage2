using Common.Network;
using LoginServer.Models;

namespace LoginServer;

public static class PacketBuilder
{
    public static Packet Init(int sessionId, byte[] publicKey, byte[] blowfishKey)
    {
        byte opcode = 0x00;
        var protocolRevision = 0x0000c621;
        var p = new Packet(opcode);
        p.WriteInt(sessionId, protocolRevision);
        p.WriteByteArray(publicKey); // RSA Public Key
        p.WriteInt(0x29DD954E, 0x77C39CFC, unchecked((int)0x97ADB620), 0x07BDE0F7); // unk GG related?
        p.WriteByteArray(blowfishKey);
        p.WriteByte(0); // null termination
        return p;
    }
    
    public static Packet LoginFail(LoginFailReason reason)
    {
        byte opcode = 0x01;

        var p = new Packet(opcode);
        p.WriteByte((byte)reason);

        return p;
    }

    public static Packet LoginOk(int loginOkId1, int loginOkId2)
    {
        byte opcode = 0x03;
        
        var p = new Packet(0x03);
        p.WriteInt(loginOkId1, loginOkId2);
        p.WriteIntArray(new int[2]);
        p.WriteInt(0x000003ea);
        p.WriteIntArray(new int[3]);
        p.WriteByteArray(new byte[16]);
        return p;
    }
    
    public static Packet ServerList(List<L2Server> servers)
    {
        byte opcode = 0x04;
        
        var p = new Packet(opcode);
        
        p.WriteByte((byte)servers.Count, 1); //(byte)client.ActiveAccount.LastServer);
        
        foreach (L2Server server in servers)
        {
            int bits = 0x40;
            if (server.TestMode)
                bits |= 0x04;

            p.WriteByte(server.Id);
            p.WriteByteArray(server.GetIp());
            p.WriteInt(server.Port);
            p.WriteByte(server.AgeLimit);
            p.WriteByte(server.IsPvp ? (byte)1 : (byte)0);
            p.WriteShort(server.CurrentPlayers);
            p.WriteShort(server.MaxPlayers);
            p.WriteByte(server.Connected? (byte)1 : (byte)0); // status
            p.WriteInt(1);//bits); // 1: Normal, 2: Relax, 4: Public Test, 8: No Label, 16: Character Creation Restricted, 32: Event, 64: Free
            p.WriteByte(server.IsBrackets ? (byte)1 : (byte)0); //brackets
        }

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

    public static Packet GGAuth(int sessionId)
    {
        byte Opcode = 0x0b;
        
        var p = new Packet(Opcode);
        p.WriteInt(sessionId);
        p.WriteByteArray(new byte[4]);
        
        return p;
    }
}