using System.Text;
using LoginServer.Network.GameApplication.ClientsNetwork;
using Org.BouncyCastle.Crypto.Engines;

namespace LoginServer.Network.GameApplication.Packets.Listenable.Handlers;

public class RequestAuthLoginHandler
{
    private L2GameApplicationAvatar _avatar;
    
    public async Task Handle(RequestAuthLogin request)
    {
        if (loginClientState != LoginClientState.AuthedGg)
        {
            await l2Connection.SendAsync(
                PacketBuilder.LoginFail(LoginFailReason.ReasonAccessFailed));
            //l2Connection.Close();
            return;
        }
        
        var decrypt = DecryptPacket(raw);

        var username = Encoding.ASCII
            .GetString(decrypt, 0x4E, 64)
            .Replace("\0", string.Empty);

        var password = Encoding.ASCII
            .GetString(decrypt, 0xDC, 16)
            .Replace("\0", string.Empty);
        
        logger.Information(
            "Username: {Username}, password: {Password}",
            username,
            password);
        
        final String clientAddr = client.getIp();
        final LoginController lc = LoginController.getInstance();
        final AccountInfo info = lc.retriveAccountInfo(clientAddr, user, password);
        if (info == null)
        {
            // Account or password was wrong.
            client.close(LoginFailReason.REASON_USER_OR_PASS_WRONG);
            return;
        }
		
        switch (lc.tryCheckinAccount(client, clientAddr, info))
        {
            case AUTH_SUCCESS:
            {
                client.setAccount(info.getLogin());
                client.setConnectionState(ConnectionState.AUTHED_LOGIN);
                client.setSessionKey(lc.assignSessionKeyToClient(info.getLogin(), client));
                lc.getCharactersOnAccount(info.getLogin());
                if (Config.SHOW_LICENCE)
                {
                    client.sendPacket(new LoginOk(client.getSessionKey()));
                }
                else
                {
                    client.sendPacket(new ServerList(client));
                }
                break;
            }
            case INVALID_PASSWORD:
            {
                client.close(LoginFailReason.REASON_USER_OR_PASS_WRONG);
                break;
            }
            case ACCOUNT_BANNED:
            {
                client.close(new AccountKicked(AccountKickedReason.REASON_PERMANENTLY_BANNED));
                return;
            }
            case ALREADY_ON_LS:
            {
                final LoginClient oldClient = lc.getAuthedClient(info.getLogin());
                if (oldClient != null)
                {
                    // Kick the other client.
                    oldClient.close(LoginFailReason.REASON_ACCOUNT_IN_USE);
                    lc.removeAuthedLoginClient(info.getLogin());
                }
				
                // Also kick current client.
                client.close(LoginFailReason.REASON_ACCOUNT_IN_USE);
                break;
            }
            case ALREADY_ON_GS:
            {
                final GameServerInfo gsi = lc.getAccountOnGameServer(info.getLogin());
                if (gsi != null)
                {
                    client.close(LoginFailReason.REASON_ACCOUNT_IN_USE);
                    if (gsi.isAuthed())
                    {
                        gsi.getGameServerThread().kickPlayer(info.getLogin());
                    }
                }
                break;
            }
        }
    }

    byte[] DecryptPacket(byte[] input)
    {
        var privateKey = _avatar.ScrambledKeyPair.privateKey;
        var rsa = new RsaEngine();
        rsa.Init(false, privateKey);

        var decrypt = rsa.ProcessBlock(input, 0, 128);
        var decrypt2 = rsa.ProcessBlock(input, 128, 128);

        var result = new byte[256];

        Array.Copy(decrypt, 0, result, 128 - decrypt.Length, decrypt.Length);
        Array.Copy(decrypt2, 0, result, 256 - decrypt2.Length, decrypt2.Length);

        return result;
    }
}