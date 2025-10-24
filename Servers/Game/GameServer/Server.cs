using GameServer.Network.GameApplication.ClientsNetwork;
using Microsoft.Extensions.Hosting;

namespace GameServer;

public class Server : IHostedService
{
    private readonly L2ConnectionsListener l2ConnectionsListener;
    //private readonly L2ServersConnectionsListener l2ServersConnectionsListener;

    public Server(L2ConnectionsListener l2ConnectionsListener)
    {
        this.l2ConnectionsListener = l2ConnectionsListener;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        l2ConnectionsListener.Start();
        //l2ServersConnectionsListener.Start();
        
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        l2ConnectionsListener.Stop();
        //l2ServersConnectionsListener.Stop();
        
        return Task.CompletedTask;
    }
}