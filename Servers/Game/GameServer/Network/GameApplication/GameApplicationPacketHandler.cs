using System.Collections.Frozen;
using Autofac;
using Common.Network;
using GameServer.Network.GameApplication.Packets.Listenable.Handlers;
using GameServer.Network.GameApplication.Packets.Listenable.Part1;
using GameServer.Network.GameApplication.Packets.Listenable.Part3;
using Serilog;

namespace GameServer.Network.GameApplication;

public class GameApplicationPacketHandler
{
    private readonly ILifetimeScope serviceProvider;
    private readonly FrozenDictionary<byte, (Type request, Type handler)> handlers;
    private readonly FrozenDictionary<int, (Type request, Type handler)> exHandlers;
    private readonly ILogger logger = Log.Logger.ForContext<GameApplicationPacketHandler>();

    public GameApplicationPacketHandler(ILifetimeScope serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        handlers = new Dictionary<byte, (Type requestType, Type handlerType)>()
        {
            // {0x00, (typeof(RequestAuthLogin), typeof(RequestAuthLoginHandler))},
            // {0x01, (typeof(RequestAuthLogin), typeof(RequestAuthLoginHandler))},
            // {0x02, (typeof(RequestAuthLogin), typeof(RequestAuthLoginHandler))},
            // {0x03, (typeof(RequestAuthLogin), typeof(RequestAuthLoginHandler))},
            // {0x04, (typeof(RequestAuthLogin), typeof(RequestAuthLoginHandler))},
            // {0x05, (typeof(RequestAuthLogin), typeof(RequestAuthLoginHandler))},
            // {0x06, (typeof(RequestAuthLogin), typeof(RequestAuthLoginHandler))},
            // {0x07, (typeof(RequestAuthLogin), typeof(RequestAuthLoginHandler))},
            // {0x00, (typeof(RequestAuthLogin), typeof(RequestAuthLoginHandler))},
            // {0x00, (typeof(RequestAuthLogin), typeof(RequestAuthLoginHandler))},
            // {0x00, (typeof(RequestAuthLogin), typeof(RequestAuthLoginHandler))},
            // {0x00, (typeof(RequestAuthLogin), typeof(RequestAuthLoginHandler))},
            {0x0E, (typeof(ProtocolVersion), typeof(ProtocolVersionHandler))},
            // {0x00, (typeof(RequestAuthLogin), typeof(RequestAuthLoginHandler))},
            // {0x00, (typeof(RequestAuthLogin), typeof(RequestAuthLoginHandler))},
            // {0x00, (typeof(RequestAuthLogin), typeof(RequestAuthLoginHandler))},
            // {0x00, (typeof(RequestAuthLogin), typeof(RequestAuthLoginHandler))},
            // {0x00, (typeof(RequestAuthLogin), typeof(RequestAuthLoginHandler))},
            // {0x00, (typeof(RequestAuthLogin), typeof(RequestAuthLoginHandler))},
            {0x2B, (typeof(AuthLogin), typeof(AuthLoginHandler))},

        }.ToFrozenDictionary();

        exHandlers = new Dictionary<int, (Type requestType, Type handlerType)>()
        {

        }.ToFrozenDictionary();
    }

    public Task HandleAsync(byte opcode, Packet packet, L2GameApplicationAvatar avatar, CancellationToken ct)
    {
        if(opcode == 0xD0)
            return HandleExAsync(packet, avatar, ct);
        
        if (!handlers.TryGetValue(opcode, out (Type requestType, Type handlerType) rh))
        {
            logger.Information("Opcode: {Opcode:X2}, для обработки клиентского пакета, не найден", opcode);
        }

        var request = Activator.CreateInstance(rh.requestType, new object[] { packet });
        
        using var scope = serviceProvider.BeginLifetimeScope();
        var handler = scope.Resolve(rh.handlerType, new TypedParameter(typeof(L2GameApplicationAvatar), avatar));
        
        var method = rh.handlerType.GetMethod(nameof(IGameApplicationHandler<object>.HandleAsync));

        var task = (Task)method.Invoke(handler, [request, ct]);

        return task;
    }

    private Task HandleExAsync(Packet packet, L2GameApplicationAvatar avatar, CancellationToken ct)
    {
        var secondOpcode = packet.SecondOpcode;
        
        if (!exHandlers.TryGetValue(secondOpcode, out (Type requestType, Type handlerType) rh))
        {
            logger.Information("Opcode: {Opcode:X2}, для обработки клиентского пакета, не найден", secondOpcode);
            return Task.CompletedTask;
        }

        var request = Activator.CreateInstance(rh.requestType, new object[] { packet });
        
        using var scope = serviceProvider.BeginLifetimeScope();
        var handler = scope.Resolve(rh.handlerType, new TypedParameter(typeof(L2GameApplicationAvatar), avatar));
        
        var method = rh.handlerType.GetMethod(nameof(IGameApplicationHandler<object>.HandleAsync));
        
        var task = (Task)method.Invoke(handler, [request, ct]);
        
        return task;
    }
}