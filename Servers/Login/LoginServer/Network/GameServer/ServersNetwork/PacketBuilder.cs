using Common.Network;
using LoginServer.Network.GameServer.Packets.Sent;

namespace LoginServer.Network.GameServer.ServersNetwork;

public static class PacketBuilder
{
    public static Packet InitLS_0x00(byte[] publicKey) //+
    {
        return new _0x00_InitLS(publicKey);
    }

    public static Packet LoginServerFail_0x01(byte reason) //-
    {
        return new _0x01_LoginServerFail(reason);
    }

    public static Packet AuthResponse_0x02(byte serverId, string serverName) //+
    {
        return new _0x02_AuthResponse(serverId,serverName );
    }

    public static Packet PlayerAuthResponse_0x03(string account, bool response) // +
    {
        return new _0x03_PlayerAuthResponse(account, response);
    }

    public static Packet KickPlayer_0x04(string account) // +
    {
        return new _0x04_KickPlayer(account);
    }

    public static Packet RequestCharacters_0x05(string account) // +
    {
        return new _0x05_RequestCharacters(account);
    }

    public static Packet ChangePasswordResponse_0x06(byte successful, string characterName, string msgToSend) // +
    {
        return new _0x06_ChangePasswordResponse(successful, characterName, msgToSend);
    }
}