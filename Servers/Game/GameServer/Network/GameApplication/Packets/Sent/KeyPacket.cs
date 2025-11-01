using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Sent;

public class KeyPacket : Packet
{
    public KeyPacket() : base(0x00)
    {
        //ServerPackets.KEY_PACKET.writeId(this, buffer);
        WriteByte(0); // 0 - wrong protocol, 1 - protocol ok
        for (int i = 0; i < 8; i++)
        {
            WriteByte(0); //_key[i]); // key
        }
        WriteInt(1); // use blowfish encryption
        WriteInt(1);//Config.SERVER_ID); // server id
        WriteByte(1);
        WriteInt(1); // obfuscation key
    }
}