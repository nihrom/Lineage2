namespace LoginServer.Network.GameApplication.Packets.Listenable.Handlers;

public class RequestServerListHandler
{
    public async Task Handle(RequestServerList request)
    {
        LoginClient client = getClient();
        if (client.getSessionKey().checkLoginPair(_skey1, _skey2))
        {
            client.sendPacket(new ServerList(client));
        }
        else
        {
            client.close(LoginFailReason.REASON_ACCESS_FAILED);
        }
    }
}