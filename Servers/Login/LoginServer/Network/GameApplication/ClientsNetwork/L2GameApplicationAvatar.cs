using System.Net.Sockets;
using Common.Cryptography;
using Common.Network;
using LoginServer.Application.Services.L2GameApplication;
using LoginServer.Network.GameApplication.Packets.Listenable;
using LoginServer.Network.GameApplication.Packets.Listenable.Handlers;
using LoginServer.Network.GameApplication.Packets.Sent;

namespace LoginServer.Network.GameApplication.ClientsNetwork;

public class L2GameApplicationAvatar : L2Connection, IL2GameApplicationClient
{
    public ScrambledKeyPair ScrambledKeyPair { get; set; }
    
    public int LoginOkId1 { get; set; }
    
    public int LoginOkId2 { get; set; }
    
    public int PlayOkId1 { get; set; }
    
    public int PlayOkId2 { get; set; }

    /// <summary>
    /// Этап соединения
    /// </summary>
    public LoginClientState LoginClientState { get; set; }
    
    /// <summary>
    /// Логин юзера. Привязывается к соеднинению после залогинивания
    /// </summary>
    public string? Login  { get; set; }
    
    /// <summary>
    /// Уровень доступа. Пока не знаю какие могут быть и откуда берутся
    /// </summary>
    public int? AccessLevel { get; set; }
    
    /// <summary>
    /// Сервер на который юзер заходил в прошлый раз
    /// </summary>
    public int? LastServer { get; set; }
    
    /// <summary>
    /// Флаг залогинен ли юзер на гейм сервере.
    /// //TODO: думаю можно объединить с другой инфой доступной после залогининвания
    /// </summary>
    public bool JoinedGs { get; set; }
    
    private readonly CancellationTokenSource cts = new ();
    
    private readonly PacketHandlersBuilder packetHandlersBuilder;

    public L2GameApplicationAvatar(
        TcpClient tcpClient,
        PacketHandlersBuilder packetHandlersBuilder) : base(tcpClient)
    {
        ScrambledKeyPair = new ScrambledKeyPair(ScrambledKeyPair.GenKeyPair());
        this.packetHandlersBuilder = packetHandlersBuilder;
        ReceivedPacket += OnReadAsync;
    }

    public async Task Close(LoginFailReason reason)
    {
        //TODO: Реализовать
    }
    
    public async Task Close(PlayFailReason reason)
    {
        //TODO: Реализовать
    }

    public bool CheckLoginOk(int loginOkId1, int loginOkId2)
    {
        return LoginOkId1 == loginOkId1 && LoginOkId2 == loginOkId2;
    }

    public async Task Init()
    {
        await SendAsync(
            new _0x00_Init(
                SessionId,
                ScrambledKeyPair.scrambledModulus,
                Crypt.Blowfish),
            false);
        
        _ = Task
            .Run(() => ReadAsync(cts.Token))
            .ContinueWith(
                _ =>
                {
                    Logger.Information("Client disposed");
                    Dispose();
                });
    }
    
    public Task SendLoginFail(LoginFailReason reason)
    {
        return SendAsync(
            new _0x01_LoginFail((byte)reason));
    }
    
    public Task SendAccountKicked(AccountKickedReason reason)
    {
        return SendAsync(
            new _0x02_AccountKicked((int)reason));
    }
    
    public Task SendLoginOk()
    {
        return SendAsync(
            new _0x03_LoginOk(LoginOkId1, LoginOkId2));
    }
    
    public Task SendServerList(
        byte serversCount,
        byte accountLastServer,
        IReadOnlyCollection<_0x04_ServerList.ServerData> servers)
    {
        return SendAsync(
            new _0x04_ServerList(serversCount, accountLastServer, servers));
    }
    
    public Task SendPlayFail(PlayFailReason reason)
    {
        return SendAsync(
            new _0x06_PlayFail((byte)reason));
    }
    
    public Task SendPlayOk()
    {
        return SendAsync(
            new _0x07_PlayOk(PlayOkId1, PlayOkId2));
    }
    
    public async Task SendGgAuth()
    {
        await SendAsync(
            new _0x0b_GGAuth(SessionId));
    }
    
    private async Task OnReadAsync(Packet packet)
    {
        switch (packet.FirstOpcode)
        {
            case 0x00:
                {
                    var requestPacket = new RequestAuthLogin(packet);
                    var handler = packetHandlersBuilder
                        .Get<RequestAuthLoginHandler>();
                    handler.Avatar = this;
                    await handler.Handle(requestPacket);
                }
                break;
            case 0x02:
                {
                    var requestPacket = new RequestServerLogin(packet);
                    var handler = packetHandlersBuilder
                        .Get<RequestServerLoginHandler>();
                    handler.Avatar = this;
                    await handler.Handle(requestPacket);
                }
                break;
            case 0x05:
                {
                    var requestPacket = new RequestServerList(packet);
                    var handler = packetHandlersBuilder
                        .Get<RequestServerListHandler>();
                    handler.Avatar = this;
                    await handler.Handle(requestPacket);
                }
                break;
            case 0x07:
                {
                    var requestPacket = new AuthGameGuard(packet);
                    var handler = packetHandlersBuilder
                        .Get<AuthGameGuardHandler>();
                    handler.Avatar = this;
                    await handler.Handle(requestPacket);
                } 
                break;
            default: break;
        }
    }
}