using System.Net.Sockets;
using Common.Network;

namespace GameServer.LoginServerNetwork;

public class LoginServerAvatar : L2LoginServerConnection
{
    public LoginServerAvatar(TcpClient tcpClient) : base(tcpClient)
    {
        ReceivedPacket += OnReadAsync;
    }

    private async Task InitLS(Packet packet)
    {
        
    }
    
    private async Task LoginServerFail(Packet packet)
    {
        
    }
    
    private async Task AuthResponse(Packet packet)
    {
        
    }
    
    private async Task PlayerAuthResponse(Packet packet)
    {
        
    }
    
    private async Task KickPlayer(Packet packet)
    {
        
    }
    
    private async Task RequestCharacters(Packet packet)
    {
        
    }
    
    private async Task ChangePasswordResponse(Packet packet)
    {
        
    }

    private async Task OnReadAsync(Packet packet)
    {
        switch (packet.FirstOpcode)
        {
            case 0x00:
                await InitLS(packet); break;
            case 0x01:
                await LoginServerFail(packet); break;
            case 0x02:
                await AuthResponse(packet);  break;
            case 0x03:
                await PlayerAuthResponse(packet);  break;
            case 0x04:
                await KickPlayer(packet);  break;
            case 0x05:
                await RequestCharacters(packet);  break;
            case 0x06:
                await ChangePasswordResponse(packet); break;
            default: break;
        }
    }
}