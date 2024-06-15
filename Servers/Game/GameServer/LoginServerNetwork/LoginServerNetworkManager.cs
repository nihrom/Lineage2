using System.Net.Sockets;

namespace GameServer.LoginServerNetwork;

public class LoginServerNetworkManager
{
    public static async Task StartAsync()
    {
        var tcp = new TcpClient();
        await tcp.ConnectAsync("127.0.0.1", 9014);
        
        var loginServerAvatar = new LoginServerAvatar(tcp);
    }
}