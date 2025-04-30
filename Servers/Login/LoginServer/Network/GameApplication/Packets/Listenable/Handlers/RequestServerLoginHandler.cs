namespace LoginServer.Network.GameApplication.Packets.Listenable.Handlers;

public class RequestServerLoginHandler
{
    public async Task Handle(RequestServerLogin handler)
    {
        LoginClient client = getClient();
        SessionKey sk = client.getSessionKey();
        
        // Если мы не предъявили лицензию, мы не сможем проверить эти значения.
        if (!Config.SHOW_LICENCE || sk.checkLoginPair(_skey1, _skey2))
        {
            if ((LoginServer.getInstance().getStatus() == ServerStatus.STATUS_DOWN) || ((LoginServer.getInstance().getStatus() == ServerStatus.STATUS_GM_ONLY) && (client.getAccessLevel() < 1)))
            {
                client.close(LoginFailReason.REASON_ACCESS_FAILED);
            }
            else if (LoginController.getInstance().isLoginPossible(client, _serverId))
            {
                client.setJoinedGS(true);
                client.sendPacket(new PlayOk(sk));
            }
            else
            {
                client.close(PlayFailReason.REASON_SERVER_OVERLOADED);
            }
        }
        else
        {
            client.close(LoginFailReason.REASON_ACCESS_FAILED);
        }
    }
}