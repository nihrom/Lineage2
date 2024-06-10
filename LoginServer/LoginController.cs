using System.Text;
using Common.Cryptography;
using Common.Network;
using Org.BouncyCastle.Crypto.Engines;
using Serilog;

namespace LoginServer;

public class LoginController
{
    private readonly ILogger logger = Log.Logger.ForContext<LoginController>();
    private readonly L2Connection l2Connection;

    private readonly int sessionId;
    private readonly ScrambledKeyPair scrambledKeyPair;
    private readonly byte[] blowfish = new byte[16];

    private int loginOkId1;
    private int loginOkId2;

    private LoginClientState loginClientState;
    
    public LoginController(L2Connection l2Connection)
    {
        this.l2Connection = l2Connection;
        l2Connection.ReceivedPacket += OnReadAsync;

        var random = new Random();

        sessionId = random.Next();
        scrambledKeyPair = new ScrambledKeyPair(ScrambledKeyPair.GenKeyPair()); //TODO: Возможно нужен пул ключей
        random.NextBytes(blowfish); //TODO: Возможно нужен пул ключей
    }

    public async Task Init()
    {
        l2Connection.Crypt.UpdateKey(blowfish);
        
        var packet = PacketBuilder.Init(
            sessionId, 
            scrambledKeyPair.scrambledModulus,
            blowfish);

        await l2Connection.SendAsync(packet);
    }

    public async Task AuthGameGuard(int _sessionId)
    {
        if (loginClientState != LoginClientState.Connected)
        {
            await l2Connection.SendAsync(
                PacketBuilder.LoginFail(LoginFailReason.ReasonAccessFailed));
            //l2Connection.Close();
            return;
        }

        if (_sessionId != sessionId)
        {
            await l2Connection.SendAsync(
                PacketBuilder.LoginFail(LoginFailReason.ReasonAccessFailed));
            //l2Connection.Close();
            return;
        }

        loginClientState = LoginClientState.AuthedGg;
        await l2Connection.SendAsync(
            PacketBuilder.GGAuth(sessionId));
    }

    public async Task RequestAuthLogin(byte[] raw, byte[] raw2, bool isNewAuthMethod)
    {
        if (loginClientState != LoginClientState.AuthedGg)
        {
            await l2Connection.SendAsync(
                PacketBuilder.LoginFail(LoginFailReason.ReasonAccessFailed));
            //l2Connection.Close();
            return;
        }
        
        var decrypt = DecryptPacket(raw, raw2, isNewAuthMethod);

        var (username, password) = ExtractEncodingPass(decrypt, isNewAuthMethod);
        
        logger.Information(
            "Username: {Username}, password: {Password}",
            username,
            password);
        
        // var account = await _accountService.GetAccountByLogin(username);
        //
        // if (account == null)
        // {
        //     if (_config.ServerConfig.AutoCreate)
        //     {
        //         account = await _accountService.CreateAccount(username, password);
        //     }
        //     else
        //     {
        //         await l2Connection.SendAsync(
        //             PacketBuilder.LoginFail(LoginFailReason.ReasonUserOrPassWrong));
        //         //l2Connection.Close();
        //         return;
        //     }
        // }
        // else
        // {
        //     if (!await _accountService.CheckIfAccountIsCorrect(username, password))
        //     {
        //         await l2Connection.SendAsync(
        //             PacketBuilder.LoginFail(LoginFailReason.ReasonUserOrPassWrong));
        //         //l2Connection.Close();
        //         return;
        //     }
        //
        //     if (LoginServer.ServiceProvider.GetService<ServerThreadPool>().LoggedAlready(username.ToLower()))
        //     {
        //         await l2Connection.SendAsync(
        //             PacketBuilder.LoginFail(LoginFailReason.ReasonAccountInUse));
        //         //l2Connection.Close();
        //         return;
        //     }
        // }
        //
        // _client.ActiveAccount = account;
        
        loginClientState = LoginClientState.AuthedLogin;

        loginOkId1 = Random.Shared.Next();
        loginOkId2 = Random.Shared.Next();
        
        await l2Connection.SendAsync(PacketBuilder.LoginOk(loginOkId1, loginOkId2));
    }
    
    (string username, string password) ExtractEncodingPass(byte[] input, bool isNewAuthMethod)
    {
        if (isNewAuthMethod)
        {
            var username = Encoding.ASCII
                .GetString(input, 0x4E, 50)
                .Replace("\0", string.Empty);
            
            username += Encoding.ASCII
                .GetString(input, 0xCE, 14)
                .Replace("\0", string.Empty);
        
            var password = Encoding.ASCII
                .GetString(input, 0xDC, 16)
                .Replace("\0", string.Empty);

            return (username, password);
        }
        else
        {
            var username = Encoding.ASCII
                .GetString(input, 0x5E, 14)
                .Replace("\0", string.Empty);
        
            var password = Encoding.ASCII
                .GetString(input, 0x6C, 16)
                .Replace("\0", string.Empty);
                
            return (username, password);
        }
    }
    
    byte[] DecryptPacket(byte[] raw, byte[]raw2, bool isNewAuthMethod)
    {
        var privateKey = scrambledKeyPair.privateKey;
        var rsa = new RsaEngine();
        rsa.Init(false, privateKey);

        var result = RsaProcessBlock(raw, raw2);

        return result;

        byte[] RsaProcessBlock(byte[] input, byte[] input2)
        {
            byte[] temp = [..input, ..input2];
            
            var decrypt = rsa.ProcessBlock(temp, 0, 128);
            var decrypt2 = rsa.ProcessBlock(temp, 128, 128);
            var tempDecrypt = new byte[128];
            var tempDecrypt2 = new byte[128];
            if (decrypt.Length < 128)
            {
                Array.Copy(decrypt, 0, tempDecrypt, 128 - decrypt.Length, decrypt.Length);
            }
            
            if (decrypt2.Length < 128)
            {
                Array.Copy(decrypt2, 0, tempDecrypt2, 128 - decrypt2.Length, decrypt2.Length);
            }

            return [..tempDecrypt, ..tempDecrypt2];
        }
    }
    
    public async Task RequestServerList(int _loginOkID1, int _loginOkID2)
    {
        if (loginClientState != LoginClientState.AuthedLogin)
        {
            await l2Connection.SendAsync(
                PacketBuilder.LoginFail(LoginFailReason.ReasonAccessFailed));
            //l2Connection.Close();
            return;
        }
        
        if (this.loginOkId1 != _loginOkID1 || this.loginOkId2 != _loginOkID2)
        {
            await l2Connection.SendAsync(
                PacketBuilder.LoginFail(LoginFailReason.ReasonAccessFailed));
            //l2Connection.Close();
            return;
        }
        
        //_client.SendAsync(ServerList.ToPacket(_client));
    }

    public async Task RequestServerLogin(int _loginOkID1, int _loginOkID2, byte _serverId)
    {
        if (loginClientState != LoginClientState.AuthedLogin)
        {
            await l2Connection.SendAsync(
                PacketBuilder.LoginFail(LoginFailReason.ReasonAccessFailed));
            //l2Connection.Close();
            return;
        }
        
        if (this.loginOkId1 != _loginOkID1 || this.loginOkId2 != _loginOkID2)
        {
            await l2Connection.SendAsync(
                PacketBuilder.LoginFail(LoginFailReason.ReasonAccessFailed));
            //l2Connection.Close();
            return;
        }
        
        //L2Server server = LoginServer.ServiceProvider.GetService<ServerThreadPool>().Get(_serverId);
        // if (server == null)
        // {
        //     await l2Connection.SendAsync(
        //         PacketBuilder.LoginFail(LoginFailReason.ReasonAccessFailed));
        //     //l2Connection.Close();
        //     return;
        // }
        //
        // if (server.Connected == 0)
        // {
        //     await l2Connection.SendAsync(
        //         PacketBuilder.LoginFail(LoginFailReason.ReasonServerMaintenance));
        //     //l2Connection.Close();
        //     return;
        // }
        //
        // await _client.SendAsync(PlayOk.ToPacket(_client));
    }

    public async Task OnReadAsync(Packet p)
    {
        switch (p.FirstOpcode)
        {
            case 0x00:
                if (p.Length >= 256)
                {
                    await RequestAuthLogin(
                        p.ReadByteArrayAlt(128),
                        p.ReadByteArrayAlt(128),
                        true);
                    break;
                }
                else if(p.Length >= 128)
                {
                    await RequestAuthLogin(
                        p.ReadByteArrayAlt(128),
                        Array.Empty<byte>(),
                        false);
                    break;
                }
                break;
            case 0x02:
                var _loginOkID1t = p.ReadInt();
                var _loginOkID2t = p.ReadInt();
                var _serverId = p.ReadByte();
                await RequestServerLogin(_loginOkID1t, _loginOkID2t, _serverId); break;
            case 0x05:
                var _loginOkID1 = p.ReadInt();
                var _loginOkID2 = p.ReadInt();
                await RequestServerList(_loginOkID1, _loginOkID2); break;
            case 0x07:
                var _sessionId = p.ReadInt();
                await AuthGameGuard(_sessionId); break;
            default: break;
        }
    }
}