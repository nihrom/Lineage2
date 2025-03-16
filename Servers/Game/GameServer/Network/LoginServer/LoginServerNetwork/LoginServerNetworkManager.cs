using System.Net.Sockets;

namespace GameServer.Network.LoginServer.LoginServerNetwork;

public class LoginServerNetworkManager
{
    public static async Task StartAsync()
    {
        var tcp = new TcpClient();
        await tcp.ConnectAsync("127.0.0.1", 9014);
        
        var loginServerAvatar = new LoginServerAvatar(tcp);
        
        _ = Task
            .Run(
                () => loginServerAvatar.ReadAsync(CancellationToken.None), 
                CancellationToken.None)
            .ContinueWith(
                _ => loginServerAvatar.Dispose(),
                CancellationToken.None);
            // .ContinueWith(
            //     _ => logger.Information("Server client disposed"),
            //     CancellationToken.None);
    }
}