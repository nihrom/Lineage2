using System.Net.Sockets;
using Common.Cryptography;
using LoginServer.Network.GameApplication.Packets.Sent;

namespace LoginServer.Network.GameApplication.ClientsNetwork;

public class L2GameApplicationAvatar : L2Connection
{
    public int SessionId { get; }
    
    public ScrambledKeyPair ScrambledKeyPair { get; set; }
    
    public byte[] Blowfish { get; set; } = new byte[16];

    public int LoginOkId1 { get; set; }
    
    public int LoginOkId2 { get; set; }

    public LoginClientState LoginClientState { get; set; }

    public L2GameApplicationAvatar(TcpClient tcpClient) : base(tcpClient)
    {
        SessionId = Random.Shared.Next();
        ScrambledKeyPair = new ScrambledKeyPair(ScrambledKeyPair.GenKeyPair());
        Random.Shared.NextBytes(Blowfish);
    }

    public async Task Init()
    {
        throw new NotImplementedException();
    }
    
    public async Task SendLoginFail()
    {
        throw new NotImplementedException();
    }
    
    public async Task SendAccountKicked()
    {
        throw new NotImplementedException();
    }
    
    public async Task SendLoginOk()
    {
        throw new NotImplementedException();
    }
    
    public async Task SendServerList()
    {
        throw new NotImplementedException();
    }
    
    public async Task SendPlayFail()
    {
        throw new NotImplementedException();
    }
    
    public async Task SendPlayOk()
    {
        throw new NotImplementedException();
    }
    
    public async Task SendGgAuth()
    {
        await SendAsync(new _0x0b_GGAuth(SessionId));
    }
}