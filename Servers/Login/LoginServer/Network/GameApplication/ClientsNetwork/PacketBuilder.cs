using Common.Network;
using LoginServer.Application.Services.L2GameApplication;
using LoginServer.Models;
using LoginServer.Network.GameApplication.Packets.Sent;

namespace LoginServer.Network.GameApplication.ClientsNetwork;

public static class PacketBuilder
{
    public static Packet Init(int sessionId, byte[] publicKey, byte[] blowfishKey)
    {
        return new _0x00_Init(sessionId, publicKey, blowfishKey);
    }
    
    public static Packet LoginFail(LoginFailReason reason)
    {
        return new _0x01_LoginFail((byte)reason);
    }

    public static Packet LoginOk(int loginOkId1, int loginOkId2)
    {
        return new _0x03_LoginOk(loginOkId1, loginOkId2);
    }
    
    public static Packet ServerList(List<L2Server> servers)
    {
        var serversData = servers
            .Select(s => new _0x04_ServerList.ServerData(
                s.Id,
                s.GetIp(),
                s.Port,
                s.AgeLimit,
                s.IsPvp,
                s.CurrentPlayers,
                s.MaxPlayers,
                s.Connected,
                s.IsBrackets,
                s.TestMode))
            .ToArray();
        
        return new _0x04_ServerList(
            (byte)servers.Count,
            1, //TODO: Передать сюда последний сервер аккаунта
            serversData);
    }

    public static Packet GGAuth(int sessionId)
    {
        return new _0x0b_GGAuth(sessionId);
    }
}