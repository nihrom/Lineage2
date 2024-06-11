using LoginServer.ClientNetwork;
using Microsoft.Extensions.Hosting;

namespace LoginServer;

public class Server : IHostedService
{
    private readonly L2ConnectionsListener l2ConnectionsListener;

    public Server(L2ConnectionsListener l2ConnectionsListener)
    {
        this.l2ConnectionsListener = l2ConnectionsListener;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        l2ConnectionsListener.Start();
        
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        l2ConnectionsListener.Stop();
        
        return Task.CompletedTask;
    }
}