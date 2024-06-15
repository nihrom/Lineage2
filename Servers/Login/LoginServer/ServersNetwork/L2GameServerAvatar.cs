using System.Net.Sockets;
using Common.Network;

namespace LoginServer.ServersNetwork;

public class L2GameServerAvatar : L2ServerConnection
{
    public L2GameServerAvatar(TcpClient tcpClient) : base(tcpClient)
    {
        ReceivedPacket += OnReadAsync;
    }

    public async Task Init()
    {
        logger.Information("Init");
    }

    private async Task GameServerAuth(Packet packet)
    {
        logger.Information("GameServerAuth");
    }
    
    private async Task PlayerInGame(Packet packet)
    {
        logger.Information("PlayerInGame");
    }
    
    private async Task PlayerLogout(Packet packet)
    {
        logger.Information("PlayerLogout");
    }
    
    private async Task ChangeAccessLevel(Packet packet)
    {
        logger.Information("ChangeAccessLevel");
    }
    
    private async Task PlayerAuthRequest(Packet packet)
    {
        logger.Information("PlayerAuthRequest");
    }
    
    private async Task ServerStatus(Packet packet)
    {
        logger.Information("ServerStatus");
    }
    
    private async Task PlayerTracert(Packet packet)
    {
        logger.Information("PlayerTracert");
    }
    
    private async Task ReplyCharacters(Packet packet)
    {
        logger.Information("ReplyCharacters");
    }
    
    private async Task RequestSendMail(Packet packet)
    {
        logger.Information("RequestSendMail");
    }
    
    private async Task RequestTempBan(Packet packet)
    {
        logger.Information("RequestTempBan");
    }
    
    private async Task ChangePassword(Packet packet)
    {
        logger.Information("ChangePassword");
    }

    private async Task OnReadAsync(Packet packet)
    {
        switch (packet.FirstOpcode)
        {
            case 0x00:
                await GameServerAuth(packet); break;
            case 0x01:
                await GameServerAuth(packet); break;
            case 0x02:
                await PlayerInGame(packet);  break;
            case 0x03:
                await PlayerLogout(packet);  break;
            case 0x04:
                await ChangeAccessLevel(packet);  break;
            case 0x05:
                await PlayerAuthRequest(packet);  break;
            case 0x06:
                await ServerStatus(packet); break;
            case 0x07:
                await PlayerTracert(packet);  break;
            case 0x08:
                await ReplyCharacters(packet);  break;
            case 0x09:
                await RequestSendMail(packet);  break;
            case 0x0A:
                await RequestTempBan(packet);  break;
            case 0x0B:
                await ChangePassword(packet); break;
            default: break;
        }
    }
}