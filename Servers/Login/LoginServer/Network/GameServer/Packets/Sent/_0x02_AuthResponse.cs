using Common.Network;

namespace LoginServer.Network.GameServer.Packets.Sent;

public class _0x02_AuthResponse : Packet
{
    public _0x02_AuthResponse(byte serverId, string serverName) : base(0x02)
    {
        WriteByte(serverId);
        WriteString(serverName);
    }
}