using System.Text;
using LoginServer.Application.Enums;
using LoginServer.Application.Services;
using LoginServer.Application.Services.L2GameApplication;
using LoginServer.Network.GameApplication.ClientsNetwork;
using LoginServer.Network.GameApplication.Packets.Sent;
using Org.BouncyCastle.Crypto.Engines;
using Serilog;

namespace LoginServer.Network.GameApplication.Packets.Listenable.Handlers;

public class RequestAuthLoginHandler
{
    private readonly ILogger logger = Log.Logger.ForContext<RequestAuthLoginHandler>();
    
    public L2GameApplicationAvatar Avatar { get; set; }
    private readonly AccountManager accountManager;
    private readonly ServerConfig serverConfig;
    private readonly ServersManager serversManager;

    public RequestAuthLoginHandler(
        AccountManager accountManager)
    {
        this.accountManager = accountManager;
        serverConfig = new ServerConfig();
        serverConfig.ShowLicence = false;
        //this.serverConfig = serverConfig;
        //this.serversManager = serversManager;
    }

    public async Task Handle(RequestAuthLogin request)
    {
        if (Avatar.LoginClientState != LoginClientState.AuthedGg)
        {
            await Avatar.Close(LoginFailReason.ReasonAccessFailed);
            return;
        }
        
        var decrypt = DecryptPacket(request.Raw);
        
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

        string clientAddr = Avatar.Ip;

        var accountInfo = accountManager.GetAccountInfo(
            clientAddr,
            username,
            password);
        
        if (accountInfo == null)
        {
            // Account or password was wrong.
            await Avatar.Close(LoginFailReason.ReasonUserOrPassWrong);
            return;
        }

        var checkinAccountResult = accountManager.TryCheckinAccount(
            //client,
            clientAddr,
            accountInfo);
        
        switch (checkinAccountResult)
        {
            case LoginResult.AuthSuccess:
            {
                Avatar.Login = accountInfo.Login;
                Avatar.LoginClientState = LoginClientState.AuthedLogin;
                
                //TODO: Проверить эту цепочку и реализовать
                //client.setSessionKey(lc.assignSessionKeyToClient(accountInfo.Login, client));
                
                //TODO: На сколько понимаю, запрашивает на серверах Characters по аккауту
                //lc.getCharactersOnAccount(accountInfo.Login);
                
                if (serverConfig.ShowLicence)
                {
                    await Avatar.SendLoginOk();
                }
                else
                {
                    var servers = serversManager.GetServers();
            
                    var mappedServers = servers
                        .Select(x => new _0x04_ServerList.ServerData(
                            x.ServerId,
                            x.Ip,
                            x.Port,
                            x.AgeLimit,
                            x.IsPvp,
                            x.CurrentPlayers,
                            x.MaxPlayers,
                            x.Connected,
                            x.IsBrackets,
                            x.TestMode))
                        .ToList();
            
                    //TODO: откуда то взять эту инфу
                    await Avatar.SendServerList(1, 1, mappedServers);
                }
                break;
            }
            case LoginResult.InvalidPassword:
            {
                await Avatar.Close(LoginFailReason.ReasonUserOrPassWrong);
                break;
            }
            case LoginResult.AccountBanned:
            {
                //await _avatar.Close(new AccountKicked(AccountKickedReason.REASON_PERMANENTLY_BANNED));
                return;
            }
            case LoginResult.AlreadyOnLs:
            {
                // LoginClient oldClient = lc.getAuthedClient(accountInfo.Login);
                // if (oldClient != null)
                // {
                //     // Кикнуть старого клиента
                //     oldClient.close(LoginFailReason.ReasonAccountInUse);
                //     lc.removeAuthedLoginClient(accountInfo.Login);
                // }
                
                // Также кикнуть ныншнего клиента
                await Avatar.Close(LoginFailReason.ReasonAccountInUse);
                break;
            }
            case LoginResult.AlreadyOnGs:
            {
                // GameServerInfo gsi = lc.getAccountOnGameServer(accountInfo.Login);
                // if (gsi != null)
                // {
                //     await _avatar.Close(LoginFailReason.ReasonAccountInUse);
                //     if (gsi.IsAuthed)
                //     {
                //         gsi.getGameServerThread().kickPlayer(accountInfo.Login);
                //     }
                // }
                break;
            }
        }
    }

    byte[] DecryptPacket(byte[] input)
    {
        var privateKey = Avatar.ScrambledKeyPair.privateKey;
        var rsa = new RsaEngine();
        rsa.Init(false, privateKey);

        var decrypt = rsa.ProcessBlock(input, 0, 128);
        var decrypt2 = rsa.ProcessBlock(input, 128, 128);

        var result = new byte[256];

        Array.Copy(
            decrypt,
            0,
            result,
            128 - decrypt.Length,
            decrypt.Length);
        
        Array.Copy(
            decrypt2,
            0,
            result,
            256 - decrypt2.Length,
            decrypt2.Length);

        return result;
    }
}