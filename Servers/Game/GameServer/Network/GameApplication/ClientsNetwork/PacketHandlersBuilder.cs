using Microsoft.Extensions.DependencyInjection;

namespace GameServer.Network.GameApplication.ClientsNetwork;

public class PacketHandlersBuilder
{
    private readonly IServiceProvider serviceProvider;

    public PacketHandlersBuilder(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public T Get<T>()
    {
        return (T)serviceProvider.GetRequiredService(typeof(T));
    }
}