using LoginServer.Network.GameApplication.ClientsNetwork;
using LoginServer.Network.GameServer.ServersNetwork;
using Microsoft.Extensions.Hosting;

namespace LoginServer;

public class Server : IHostedService
{
    private readonly L2ConnectionsListener l2ConnectionsListener;
    private readonly L2ServersConnectionsListener l2ServersConnectionsListener;

    public Server(
        L2ConnectionsListener l2ConnectionsListener,
        L2ServersConnectionsListener l2ServersConnectionsListener)
    {
        this.l2ConnectionsListener = l2ConnectionsListener;
        this.l2ServersConnectionsListener = l2ServersConnectionsListener;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        l2ConnectionsListener.Start();
        l2ServersConnectionsListener.Start();
        
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        l2ConnectionsListener.Stop();
        l2ServersConnectionsListener.Stop();
        
        return Task.CompletedTask;
    }
}