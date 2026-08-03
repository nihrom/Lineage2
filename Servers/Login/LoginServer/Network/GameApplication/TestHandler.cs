using System.Reflection;
using Common.Network;
using LoginServer.Network.GameApplication.ClientsNetwork;
using LoginServer.Network.GameApplication.Packets.Listenable;
using LoginServer.Network.GameApplication.Packets.Listenable.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace LoginServer.Network.GameApplication;

public class TestHandler
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IReadOnlyDictionary<byte, (Type request, Type handler)> handlers;

    public TestHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        handlers = new Dictionary<byte, (Type request, Type handler)>()
        {
            {0x00, (typeof(RequestAuthLogin), typeof(RequestAuthLoginHandler))},
            {0x02, (typeof(RequestServerLogin), typeof(RequestServerLoginHandler))},
            {0x05, (typeof(RequestServerList), typeof(RequestServerListHandler))},
            {0x07, (typeof(AuthGameGuard), typeof(AuthGameGuardHandler))},
        };
    }

    public Task HandleAsync(byte opcode, Packet packet, L2GameApplicationAvatar avatar, CancellationToken ct)
    {
        if (!handlers.TryGetValue(opcode, out var rh))
        {
            //Записать в лог, что код не найден
        }

        var request = Activator.CreateInstance(rh.request, new object[] { packet });
        
        using var scope = _serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService(rh.handler);

        var field = rh.handler.GetProperty("Avatar");
        
        field?.SetValue(handler, avatar);
        
        var method = rh.handler.GetMethod("Handle");

        var task = (Task)method.Invoke(handler, [request]);

        return task;
    }
}