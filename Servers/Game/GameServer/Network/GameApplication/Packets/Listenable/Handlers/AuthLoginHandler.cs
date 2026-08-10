using GameServer.Network.GameApplication.Packets.Listenable.Part1;
using GameServer.Network.GameApplication.Packets.Sent;

namespace GameServer.Network.GameApplication.Packets.Listenable.Handlers;

public class AuthLoginHandler : BaseGameApplicationHandler, IGameApplicationHandler<AuthLogin>
{
    public async Task HandleAsync(AuthLogin request, CancellationToken ct)
    {
        await Avatar.SendAsync(new CharSelectionInfo(), ct: ct);
    }
}