using System.Collections.Frozen;
using Autofac;
using Common.Network;
using LoginServer.Network.GameServer.Packets.Listenable;
using LoginServer.Network.GameServer.Packets.Listenable.Handlers;
using Serilog;

namespace LoginServer.Network.GameServer;

public class GameServerPacketHandler
{
    private readonly ILifetimeScope serviceProvider;
    private readonly FrozenDictionary<byte, (Type request, Type handler)> handlers;
    private readonly ILogger logger = Log.Logger.ForContext<GameServerPacketHandler>();

    public GameServerPacketHandler(ILifetimeScope serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        handlers = new Dictionary<byte, (Type requestType, Type handlerType)>()
        {
            {0x00, (typeof(BlowFishKey), typeof(BlowFishKeyHandler))},
            {0x01, (typeof(GameServerAuth), typeof(GameServerAuthHandler))},
            {0x02, (typeof(PlayerInGame), typeof(PlayerInGameHandler))},
            {0x03, (typeof(PlayerLogout), typeof(PlayerLogoutHandler))},
            {0x04, (typeof(ChangeAccessLevel), typeof(ChangeAccessLevelHandler))},
            {0x05, (typeof(PlayerAuthRequest), typeof(PlayerAuthRequestHandler))},
            {0x06, (typeof(ServerStatus), typeof(ServerStatusHandler))},
            {0x07, (typeof(PlayerTracert), typeof(PlayerTracertHandler))},
            {0x08, (typeof(ReplyCharacters), typeof(ReplyCharactersHandler))},
            {0x09, (typeof(RequestSendMail), typeof(RequestSendMailHandler))},
            {0x0A, (typeof(RequestTempBan), typeof(RequestTempBanHandler))},
            {0x0B, (typeof(ChangePassword), typeof(ChangePasswordHandler))},

        }.ToFrozenDictionary();
    }

    public Task HandleAsync(
        byte opcode,
        Packet packet,
        L2GameServerAvatar avatar,
        CancellationToken ct)
    {
        if (!handlers.TryGetValue(opcode, out (Type requestType, Type handlerType) rh))
        {
            logger.Information("Opcode: {Opcode}, для обработки клиентского пакета, не найден", opcode);
        }

        var request = Activator.CreateInstance(rh.requestType, new object[] { packet });
        
        using var scope = serviceProvider.BeginLifetimeScope();
        var handler = scope.Resolve(rh.handlerType, new TypedParameter(typeof(L2GameServerAvatar), avatar));
        
        var method = rh.handlerType.GetMethod("Handle");

        var task = (Task)method.Invoke(handler, [request]);

        return task;
    }
}