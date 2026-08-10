namespace GameServer.Network.GameApplication.Packets.Listenable.Handlers;

public interface IGameApplicationHandler<TRequest>
{
    L2GameApplicationAvatar Avatar { get; init; }

    Task HandleAsync(TRequest request, CancellationToken ct);
}