using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Sent;

public class KeyPacket : Packet
{
    public KeyPacket(byte[] key, byte result = 1) : base(0x2E)
    {
        WriteByte(result); // 0 - wrong protocol, 1 - protocol ok
        for (int i = 0; i < 8; i++)
        {
            WriteByte(0); //_key[i]); // key
        }
        WriteInt(1); // Config.PACKET_ENCRYPTION use blowfish encryption //TODO достать из конфига
        WriteInt(1);// Config.SERVER_ID server id //TODO достать из конфига
        WriteByte(1);
        WriteInt(0); // obfuscation key
        WriteByte(1); // (Config.SERVER_LIST_TYPE & 0x400) == 0x400 //TODO достать из конфига
    }
}