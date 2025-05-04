using LoginServer.Application.Services.L2GameApplication;
using LoginServer.Network.GameApplication.ClientsNetwork;

namespace LoginServer.Network.GameApplication.Packets.Listenable.Handlers;

public class AuthGameGuardHandler
{
    private L2GameApplicationAvatar _avatar;
    
    public async Task Handle(AuthGameGuard request)
    {
        if (_avatar.SessionId == request.SessionId)
        {
            _avatar.LoginClientState = LoginClientState.AuthedGg;
            await _avatar.SendGgAuth();
        }
        else
        {
            await _avatar.Close(LoginFailReason.ReasonAccessFailed);
        }
    }
}