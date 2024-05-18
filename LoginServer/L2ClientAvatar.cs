using System.Net.Sockets;

namespace LoginServer;

public class L2ClientAvatar
{
    private readonly L2Connection l2Connection;
    private readonly LoginController loginController;

    public L2ClientAvatar(TcpClient tcpClient)
    {
        var connection = new L2Connection(tcpClient);
        var loginController = new LoginController(connection);
        
        Task.Run(() => connection.ReadAsync(ct))
            .ContinueWith(antecedent => client.Dispose())
            .ContinueWith(antecedent => logger.Information("Client disposed"));
    }
}