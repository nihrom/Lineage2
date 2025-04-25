using Common.Network;

namespace GameServer.Network.LoginServer.Packets.Sent;

public class _0x03_PlayerLogout : Packet
{
    public _0x03_PlayerLogout(string player) : base(0x03)
    {
        WriteString(player);
    }
}