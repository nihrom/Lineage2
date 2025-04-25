using Common.Network;

namespace GameServer.Network.LoginServer.Packets.Sent;

public class _0x05_PlayerAuthRequest : Packet
{
    public record SessionKey(
        int PlayOkId1,
        int PlayOkId2,
        int LoginOkId1,
        int LoginOkId2);

    public _0x05_PlayerAuthRequest(
        string account,
        SessionKey key) : base(0x05)
    {
        WriteString(account);
        WriteInt(key.PlayOkId1);
        WriteInt(key.PlayOkId2);
        WriteInt(key.LoginOkId1);
        WriteInt(key.LoginOkId2);
    }
}