using Common.Network;

namespace LoginServer.Network.GameServer.Packets.Sent;

public class _0x00_InitLS : Packet
{
    private const int ProtocolRevision = 0x0106;
    
    public _0x00_InitLS(byte[] publicKey) : base(0x00)
    {
        WriteInt(ProtocolRevision);
        WriteInt(publicKey.Length);
        WriteByte(publicKey);
    }
}