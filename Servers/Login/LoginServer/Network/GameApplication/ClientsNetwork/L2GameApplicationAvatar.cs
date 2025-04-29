using System.Net.Sockets;

namespace LoginServer.Network.GameApplication.ClientsNetwork;

public class L2GameApplicationAvatar : L2Connection
{
    public int SessionId { get; }

    public L2GameApplicationAvatar(TcpClient tcpClient) : base(tcpClient)
    {
        
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
        throw new NotImplementedException();
    }
}