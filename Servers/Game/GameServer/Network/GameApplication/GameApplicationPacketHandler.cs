using System.Collections.Frozen;
using Autofac;
using Common.Network;
using Serilog;

namespace GameServer.Network.GameApplication;

public class GameApplicationPacketHandler
{
    private readonly ILifetimeScope serviceProvider;
    private readonly FrozenDictionary<byte, (Type request, Type handler)> handlers;
    private readonly ILogger logger = Log.Logger.ForContext<GameApplicationPacketHandler>();

    public GameApplicationPacketHandler(ILifetimeScope serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        handlers = new Dictionary<byte, (Type requestType, Type handlerType)>()
        {
            // {0x00, (typeof(RequestAuthLogin), typeof(RequestAuthLoginHandler))},
            // {0x02, (typeof(RequestServerLogin), typeof(RequestServerLoginHandler))},
            // {0x05, (typeof(RequestServerList), typeof(RequestServerListHandler))},
            // {0x07, (typeof(AuthGameGuard), typeof(AuthGameGuardHandler))},
        }.ToFrozenDictionary();
    }

    public Task HandleAsync(byte opcode, Packet packet, L2GameApplicationAvatar avatar, CancellationToken ct)
    {
        if (!handlers.TryGetValue(opcode, out (Type requestType, Type handlerType) rh))
        {
            logger.Information("Opcode: {Opcode}, для обработки клиентского пакета, не найден", opcode);
        }

        var request = Activator.CreateInstance(rh.requestType, new object[] { packet });
        
        using var scope = serviceProvider.BeginLifetimeScope();
        var handler = scope.Resolve(rh.handlerType, new TypedParameter(typeof(L2GameApplicationAvatar), avatar));
        
        var method = rh.handlerType.GetMethod("Handle");

        var task = (Task)method.Invoke(handler, [request]);

        return task;
    }
}