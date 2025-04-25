using Common.Network;

namespace GameServer.Network.LoginServer.Packets.Sent;

public class _0x04_ChangeAccessLevel : Packet
{
    public _0x04_ChangeAccessLevel(
        int access,
        string player) : base(0x04)
    {
        WriteInt(access);
        WriteString(player);
    }
}