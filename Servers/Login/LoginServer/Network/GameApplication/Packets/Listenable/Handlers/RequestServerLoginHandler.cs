using LoginServer.Application.Services;
using LoginServer.Application.Services.L2GameApplication;
using LoginServer.Network.GameApplication.ClientsNetwork;

namespace LoginServer.Network.GameApplication.Packets.Listenable.Handlers;

public class RequestServerLoginHandler
{
    public L2GameApplicationAvatar Avatar { get; set; }
    private Application.Services.LoginServer _server;
    private readonly AccountManager accountManager;
    private readonly ServerConfig serverConfig;
    
    public async Task Handle(RequestServerLogin request)
    {
        // Если мы не предъявили лицензию, мы не сможем проверить эти значения.
        if (!serverConfig.ShowLicence || Avatar.CheckLoginOk(request.Skey1, request.Skey2))
        {
            if (
                _server.Status == LoginServerStatus.StatusDown ||
                (_server.Status == LoginServerStatus.StatusGmOnly && Avatar.AccessLevel < 1))
            {
                await Avatar.Close(LoginFailReason.ReasonAccessFailed);
            }
            else if (accountManager.IsLoginPossible(
                         //client, 
                         request.ServerId))
            {
                Avatar.JoinedGs = true;
                await Avatar.SendPlayOk();
            }
            else
            {
                await Avatar.Close(PlayFailReason.REASON_SERVER_OVERLOADED);
            }
        }
        else
        {
            await Avatar.Close(LoginFailReason.ReasonAccessFailed);
        }
    }
}