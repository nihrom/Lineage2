using LoginServer.Application.Services.L2GameApplication;
using LoginServer.Network.GameApplication.ClientsNetwork;

namespace LoginServer.Network.GameApplication.Packets.Listenable.Handlers;

public class AuthGameGuardHandler
{
    public L2GameApplicationAvatar Avatar {get; set;}
    
    public async Task Handle(AuthGameGuard request)
    {
        if (Avatar.SessionId == request.SessionId)
        {
            Avatar.LoginClientState = LoginClientState.AuthedGg;
            await Avatar.SendGgAuth();
        }
        else
        {
            await Avatar.Close(LoginFailReason.ReasonAccessFailed);
        }
    }
}