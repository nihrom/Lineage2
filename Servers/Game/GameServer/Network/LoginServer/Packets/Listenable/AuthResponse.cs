using Common.Network;

namespace GameServer.Network.LoginServer.Packets.Listenable;

public class AuthResponse
{
    public int ServerId { get; }
    
    public string ServerName { get; }

    public AuthResponse(Packet packet)
    {
        ServerId = packet.ReadByte();
        ServerName = packet.ReadString();
    }
}