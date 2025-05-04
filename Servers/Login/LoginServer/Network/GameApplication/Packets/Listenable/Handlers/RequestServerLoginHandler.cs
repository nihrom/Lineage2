using LoginServer.Application.Services;
using LoginServer.Network.GameApplication.ClientsNetwork;

namespace LoginServer.Network.GameApplication.Packets.Listenable.Handlers;

public class RequestServerLoginHandler
{
    private L2GameApplicationAvatar _avatar;
    private Application.Services.LoginServer _server;
    private readonly AccountManager accountManager;
    private readonly ServerConfig serverConfig;
    
    public async Task Handle(RequestServerLogin request)
    {
        // Если мы не предъявили лицензию, мы не сможем проверить эти значения.
        if (!serverConfig.ShowLicence || _avatar.CheckLoginOk(request.Skey1, request.Skey2))
        {
            if (
                _server.Status == LoginServerStatus.StatusDown ||
                (_server.Status == LoginServerStatus.StatusGmOnly && _avatar.AccessLevel < 1))
            {
                await _avatar.Close(LoginFailReason.ReasonAccessFailed);
            }
            else if (accountManager.IsLoginPossible(
                         //client, 
                         request.ServerId))
            {
                _avatar.JoinedGs = true;
                await _avatar.SendPlayOk();
            }
            else
            {
                _avatar.Close(PlayFailReason.REASON_SERVER_OVERLOADED);
            }
        }
        else
        {
            await _avatar.Close(LoginFailReason.ReasonAccessFailed);
        }
    }
}