using System.Collections.Frozen;
using Autofac;
using Common.Network;
using GameServer.Network.LoginServer.Packets.Listenable;
using GameServer.Network.LoginServer.Packets.Listenable.Handlers;
using Serilog;

namespace GameServer.Network.LoginServer;

public class LoginServerPacketHandler
{
    private readonly ILifetimeScope serviceProvider;
    private readonly FrozenDictionary<byte, (Type request, Type handler)> handlers;
    private readonly ILogger logger = Log.Logger.ForContext<LoginServerPacketHandler>();

    public LoginServerPacketHandler(ILifetimeScope serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        handlers = new Dictionary<byte, (Type requestType, Type handlerType)>()
        {
            {0x00, (typeof(InitLS), typeof(InitLSHandler))},
            {0x01, (typeof(LoginServerFail), typeof(LoginServerFailHandler))},
            {0x02, (typeof(AuthResponse), typeof(AuthResponseHandler))},
            {0x03, (typeof(PlayerAuthResponse), typeof(PlayerAuthResponseHandler))},
            {0x04, (typeof(KickPlayer), typeof(KickPlayerHandler))},
            {0x05, (typeof(RequestCharacters), typeof(RequestCharactersHandler))},
            {0x06, (typeof(ChangePasswordResponse), typeof(ChangePasswordResponseHandler))},


        }.ToFrozenDictionary();
    }

    public Task HandleAsync(
        byte opcode,
        Packet packet,
        LoginServerAvatar avatar,
        CancellationToken ct)
    {
        if (!handlers.TryGetValue(opcode, out (Type requestType, Type handlerType) rh))
        {
            logger.Information("Opcode: {Opcode}, для обработки клиентского пакета, не найден", opcode);
        }

        var request = Activator.CreateInstance(rh.requestType, new object[] { packet });
        
        using var scope = serviceProvider.BeginLifetimeScope();
        var handler = scope.Resolve(rh.handlerType, new TypedParameter(typeof(LoginServerAvatar), avatar));
        
        var method = rh.handlerType.GetMethod("Handle");

        var task = (Task)method.Invoke(handler, [request]);

        return task;
    }
}