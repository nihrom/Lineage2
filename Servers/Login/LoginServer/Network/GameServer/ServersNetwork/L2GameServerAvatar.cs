using System.Net.Sockets;
using Common.Cryptography;
using Common.Network;

namespace LoginServer.Network.GameServer.ServersNetwork;

public class L2GameServerAvatar : L2ServerConnection
{
    private readonly ScrambledKeyPair scrambledKeyPair;
    
    public L2GameServerAvatar(TcpClient tcpClient) : base(tcpClient)
    {
        ReceivedPacket += OnReadAsync;
        
        scrambledKeyPair = new ScrambledKeyPair(ScrambledKeyPair.GenKeyPair());
    }
    
    #region Методы отправки

    public async Task Init()
    {
        var packet = PacketBuilder.InitLS_0x00(
            scrambledKeyPair.scrambledModulus);
        
        await SendAsync(packet);
    }

    #endregion

    #region Обработчики пакетов отправленных с игрового сервера

    private async Task OnPacket_00(Packet packet) //+-
    {
        logger.Information("GameServerAuth");
        
        // Тут отправляется BlowFishKey
    }
    
    private async Task OnGameServerAuth(Packet packet)
    {
        logger.Information("GameServerAuth");

        var desiredId = packet.ReadByte();
        var acceptAlternativeId = packet.ReadByte() != 0;
        var hostReserved = packet.ReadByte() != 0;
        var port = packet.ReadShort();
        var maxPlayer = packet.ReadInt();
        var sizeHexIdArray = packet.ReadInt();
        var hexId = packet.ReadBytesArray(sizeHexIdArray);
        var sizeHostsIdArray = packet.ReadInt() * 2;

        var hosts = new List<string>();
        for (int i = 0; i < sizeHostsIdArray; i++)
        {
            hosts.Add(packet.ReadString());
        }

        if (HandleRegProcess())
        {
            await SendAsync(
                PacketBuilder.AuthResponse_0x02(
                    1,
                    "SuperServer"));
        }

        bool HandleRegProcess()
        {
            // Тут дофига какой то логики, пока непонятно её предназначение
            return true;
        }
    }
    
    private async Task OnPlayerInGame(Packet packet)
    {
        logger.Information("PlayerInGame");
    }
    
    private async Task OnPlayerLogout(Packet packet)
    {
        logger.Information("PlayerLogout");
    }
    
    private async Task OnChangeAccessLevel(Packet packet)
    {
        logger.Information("ChangeAccessLevel");
    }
    
    private async Task OnPlayerAuthRequest(Packet packet)
    {
        logger.Information("PlayerAuthRequest");
    }
    
    private async Task OnServerStatus(Packet packet)
    {
        logger.Information("ServerStatus");
    }
    
    private async Task OnPlayerTracert(Packet packet)
    {
        logger.Information("PlayerTracert");
    }
    
    private async Task OnReplyCharacters(Packet packet)
    {
        logger.Information("ReplyCharacters");
    }
    
    private async Task OnRequestSendMail(Packet packet)
    {
        logger.Information("RequestSendMail");
    }
    
    private async Task OnRequestTempBan(Packet packet)
    {
        logger.Information("RequestTempBan");
    }
    
    private async Task OnChangePassword(Packet packet)
    {
        logger.Information("ChangePassword");
    }

    #endregion
    

    private async Task OnReadAsync(Packet packet)
    {
        switch (packet.FirstOpcode)
        {
            case 0x00:
                await OnPacket_00(packet); break;
            case 0x01:
                await OnGameServerAuth(packet); break;
            case 0x02:
                await OnPlayerInGame(packet);  break;
            case 0x03:
                await OnPlayerLogout(packet);  break;
            case 0x04:
                await OnChangeAccessLevel(packet);  break;
            case 0x05:
                await OnPlayerAuthRequest(packet);  break;
            case 0x06:
                await OnServerStatus(packet); break;
            case 0x07:
                await OnPlayerTracert(packet);  break;
            case 0x08:
                await OnReplyCharacters(packet);  break;
            case 0x09:
                await OnRequestSendMail(packet);  break;
            case 0x0A:
                await OnRequestTempBan(packet);  break;
            case 0x0B:
                await OnChangePassword(packet); break;
            default: break;
        }
    }
}