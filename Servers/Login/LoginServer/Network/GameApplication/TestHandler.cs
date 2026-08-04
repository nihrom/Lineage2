using Autofac;
using Common.Network;
using LoginServer.Network.GameApplication.ClientsNetwork;
using LoginServer.Network.GameApplication.Packets.Listenable;
using LoginServer.Network.GameApplication.Packets.Listenable.Handlers;
using Serilog;

namespace LoginServer.Network.GameApplication;

public class TestHandler
{
    private readonly ILifetimeScope serviceProvider;
    private readonly IReadOnlyDictionary<byte, (Type request, Type handler)> handlers;
    protected readonly ILogger Logger = Log.Logger.ForContext<TestHandler>();

    public TestHandler(ILifetimeScope serviceProvider)
    {
        this.serviceProvider = serviceProvider;
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
            Logger.Information("Opcode: {Opcode}, для обработки клиентского пакета, не найден", opcode);
        }

        var request = Activator.CreateInstance(rh.request, new object[] { packet });
        
        using var scope = serviceProvider.BeginLifetimeScope();
        var handler = scope.Resolve(rh.handler, new TypedParameter(typeof(L2GameApplicationAvatar), avatar));
        
        var method = rh.handler.GetMethod("Handle");

        var task = (Task)method.Invoke(handler, [request]);

        return task;
    }
}