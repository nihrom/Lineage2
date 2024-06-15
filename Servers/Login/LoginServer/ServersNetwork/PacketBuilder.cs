using Common.Network;

namespace LoginServer.ServersNetwork;

public static class PacketBuilder
{
    public static Packet InitLS_0x00(int protocolRev, byte[] publicKey) //+
    {
        var p = new Packet(0x00);
        p.WriteInt(protocolRev);
        p.WriteInt(publicKey.Length);
        p.WriteByte(publicKey);

        return p;
    }

    public static Packet LoginServerFail_0x01(int reason) //-
    {
        // public static final int REASON_IP_BANNED = 1;
        // public static final int REASON_IP_RESERVED = 2;
        // public static final int REASON_WRONG_HEXID = 3;
        // public static final int REASON_ID_RESERVED = 4;
        // public static final int REASON_NO_FREE_ID = 5;
        // public static final int NOT_AUTHED = 6;
        // public static final int REASON_ALREADY_LOGGED8IN = 7;
        
        var p = new Packet(0x01);
        p.WriteInt(reason);

        return p;
    }

    public static Packet AuthResponse_0x02(byte serverId, string serverName) //+
    {
        var p = new Packet(0x02);
        p.WriteByte(serverId);
        p.WriteString(serverName);

        return p;
    }

    public static Packet PlayerAuthResponse_0x03(string account, bool response) // +
    {
        var p = new Packet(0x03);
        p.WriteString(account);
        p.WriteByte(response ? (byte)1 : (byte)0);

        return p;
    }

    public static Packet KickPlayer_0x04(string account) // +
    {
        var p = new Packet(0x04);
        p.WriteString(account);

        return p;
    }

    public static Packet RequestCharacters_0x05(string account) // +
    {
        var p = new Packet(0x05);
        p.WriteString(account);

        return p;
    }

    public static Packet ChangePasswordResponse_0x06(byte successful, string characterName, string msgToSend) // +
    {
        var p = new Packet(0x06);
        // writeByte(successful); // 0 false, 1 true //TODO: Разобраться со стороны гейм сервера надо ли. Неизвестно почему не отправляется
        p.WriteString(characterName);
        p.WriteString(msgToSend);

        return p;
    }
}