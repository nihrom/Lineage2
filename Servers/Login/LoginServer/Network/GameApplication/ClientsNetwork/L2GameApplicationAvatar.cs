using System.Net.Sockets;
using Common.Cryptography;
using LoginServer.Application.Services.L2GameApplication;
using LoginServer.Network.GameApplication.Packets.Sent;

namespace LoginServer.Network.GameApplication.ClientsNetwork;

public class L2GameApplicationAvatar : L2Connection
{
    public int SessionId { get; }
    
    public ScrambledKeyPair ScrambledKeyPair { get; set; }
    
    public byte[] Blowfish { get; set; } = new byte[16];

    public int LoginOkId1 { get; set; }
    
    public int LoginOkId2 { get; set; }
    
    public int PlayOkId1 { get; set; }
    
    public int PlayOkId2 { get; set; }

    public LoginClientState LoginClientState { get; set; }
    
    public string? Login  { get; set; }
    
    public int? AccessLevel { get; set; }
    
    public int? LastServer { get; set; }
    
    public bool JoinedGs { get; set; }

    public L2GameApplicationAvatar(TcpClient tcpClient) : base(tcpClient)
    {
        SessionId = Random.Shared.Next();
        ScrambledKeyPair = new ScrambledKeyPair(ScrambledKeyPair.GenKeyPair());
        Random.Shared.NextBytes(Blowfish);
    }

    public async Task Close(LoginFailReason reason)
    {
        //TODO: Реализовать
    }
    
    public async Task Close(PlayFailReason reason)
    {
        //TODO: Реализовать
    }

    public bool CheckLoginOk(int loginOkId1, int loginOkId2)
    {
        return LoginOkId1 == loginOkId1 && LoginOkId2 == loginOkId2;
    }

    public async Task Init()
    {
        await SendAsync(new _0x00_Init(
            SessionId,
            ScrambledKeyPair.scrambledModulus,
            Blowfish));
    }
    
    public Task SendLoginFail(LoginFailReason reason)
    {
        return SendAsync(
            new _0x01_LoginFail((byte)reason));
    }
    
    public Task SendAccountKicked(AccountKickedReason reason)
    {
        return SendAsync(
            new _0x02_AccountKicked((int)reason));
    }
    
    public Task SendLoginOk()
    {
        return SendAsync(
            new _0x03_LoginOk(LoginOkId1, LoginOkId2));
    }
    
    public Task SendServerList(
        byte serversCount,
        byte accountLastServer,
        IReadOnlyCollection<_0x04_ServerList.ServerData> servers)
    {
        return SendAsync(
            new _0x04_ServerList(serversCount, accountLastServer, servers));
    }
    
    public Task SendPlayFail(PlayFailReason reason)
    {
        return SendAsync(
            new _0x06_PlayFail((byte)reason));
    }
    
    public Task SendPlayOk()
    {
        return SendAsync(
            new _0x07_PlayOk(PlayOkId1, PlayOkId2));
    }
    
    public async Task SendGgAuth()
    {
        await SendAsync(
            new _0x0b_GGAuth(SessionId));
    }
}