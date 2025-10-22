using Microsoft.Extensions.DependencyInjection;

namespace LoginServer.Network.GameApplication.ClientsNetwork;

public class PacketHandlersBuilder
{
    private IServiceProvider serviceProvider;

    public PacketHandlersBuilder(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public T Get<T>()
    {
        return (T)serviceProvider.GetRequiredService(typeof(T));
    }
}