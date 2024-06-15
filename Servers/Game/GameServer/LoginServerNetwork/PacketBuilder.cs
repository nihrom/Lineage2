using Common.Network;

namespace GameServer.LoginServerNetwork;

public static class PacketBuilder
{
    public static Packet BlowFishKey(byte[] blowfishKey)//, RSAPublicKey publicKey) //-
    {
        var p = new Packet(0x00);
        
        try
        {
            // final Cipher rsaCipher = Cipher.getInstance("RSA/ECB/nopadding");
            // rsaCipher.init(Cipher.ENCRYPT_MODE, publicKey);
            // final byte[] encrypted = rsaCipher.doFinal(blowfishKey);
            // p.WriteInt(encrypted.length);
            // p.WriteBytes(encrypted);
        }
        catch (Exception e)
        {
           
        }

        return p;
    }

    public static Packet AuthRequest(
        byte id,
        bool acceptAlternate,
        byte[] hexId,
        int port,
        bool reserveHost,
        int maxplayer,
        List<string> subnets,
        List<string> hosts) //+
    {
        var p = new Packet(0x01); 
        
        p.WriteByte(id);
        p.WriteByte(acceptAlternate ? (byte)0x01 : (byte)0x00);
        p.WriteByte(reserveHost ? (byte)0x01 : (byte)0x00);
        p.WriteShort((short)port);
        p.WriteInt(maxplayer);
        p.WriteInt(hexId.Length);
        p.WriteByteArray(hexId);;
        p.WriteInt(subnets.Count);
        for (var i = 0; i < subnets.Count; i++)
        {
            p.WriteString(subnets[i]);
            p.WriteString(hosts[i]);
        }
        
        return p;
    }
    
    public static Packet PlayerInGame(string player) //+
    {
        var p = new Packet(0x02);
        p.WriteShort(1);
        p.WriteString(player);
        
        return p;
    }
    
    public static Packet PlayerLogout(string player) //+
    {
        var p = new Packet(0x03);
        p.WriteString(player);
        
        return p;
    }
    
    public static Packet ChangeAccessLevel(string player, int access) //+
    {
        var p = new Packet(0x04);
        p.WriteInt(access);
        p.WriteString(player);
        
        return p;
    } 
    
    public static Packet PlayerAuthRequest(string account, SessionKey key) //+
    {
        var p = new Packet(0x05);
        p.WriteString(account);
        p.WriteInt(key.PlayOkID1);
        p.WriteInt(key.PlayOkID2);
        p.WriteInt(key.LoginOkID1);
        p.WriteInt(key.LoginOkID2);
        
        return p;
    }
    
    public static Packet ServerStatus() //-
    {
        var p = new Packet(0x06);
        // p.WriteInt(_attributes.size());
        // for (Attribute temp : _attributes)
        // {
        //     p.WriteInt(temp.id);
        //     p.WriteInt(temp.value);
        // }
        
        return p;
    }
    
    
    public static Packet PlayerTracert(string account, string pcIp, string hop1, string hop2, string hop3, string hop4) //+
    {
        var p = new Packet(0x07);
        p.WriteString(account);
        p.WriteString(pcIp);
        p.WriteString(hop1);
        p.WriteString(hop2);
        p.WriteString(hop3);
        p.WriteString(hop4);
        
        return p;
    }
    
    public static Packet ReplyCharacters(string account, byte chars, List<long> timeToDel) //+
    {
        var p = new Packet(0x08);
        p.WriteString(account);
        p.WriteByte(chars);
        p.WriteByte((byte)timeToDel.Count);
        foreach (var time in timeToDel)
        {
            p.WriteLong(time);
        }
        
        return p;
    }
    
    public static Packet SendMail(string accountName, string mailId) //+-
    {
        var p = new Packet(0x09);
        p.WriteString(accountName);
        p.WriteString(mailId);
        // p.WriteByte(args.length);
        // for (string arg : args)
        // {
        //     p.WriteString(arg);
        // }
        
        return p;
    }
    
    
    public static Packet TempBan(string accountName, string ip, long time) //+
    {
        var p = new Packet(0x0A);
        p.WriteString(accountName);
        p.WriteString(ip);
        p.WriteLong(DateTime.UtcNow.Millisecond + (time * 60000));
        p.WriteByte(0x00);
        
        return p;
    }
    
    public static Packet ChangePassword(string accountName, string characterName, string oldPass, string newPass) //+
    {
        var p = new Packet(0x0B);
        p.WriteString(accountName);
        p.WriteString(characterName);
        p.WriteString(oldPass);
        p.WriteString(newPass);
        
        return p;
    }
}