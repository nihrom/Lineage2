using Common.Network;

namespace GameServer.Network.LoginServer.Packets.Listenable;

public class PlayerAuthResponse
{
    public string Account { get; }
    
    public bool Authed { get; }

    public PlayerAuthResponse(Packet packet)
    {
        Account = packet.ReadString();
        Authed = packet.ReadByte() != 0;
    }
}