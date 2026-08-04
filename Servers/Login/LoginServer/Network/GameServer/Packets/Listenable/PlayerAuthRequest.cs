using Common.Network;

namespace LoginServer.Network.GameServer.Packets.Listenable;

public class PlayerAuthRequest
{
    public string Account { get; }
    
    public int PlayKey1 { get; }
    
    public int PlayKey2 { get; }
    
    public int LoginKey1 { get; }
    
    public int LoginKey2 { get; }
    
    public PlayerAuthRequest(Packet packet)
    {
        Account = packet.ReadString();
        PlayKey1 = packet.ReadInt();
        PlayKey2 = packet.ReadInt();
        LoginKey1 = packet.ReadInt();
        LoginKey2 = packet.ReadInt();
    }
}