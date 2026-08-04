using Common.Network;

namespace LoginServer.Network.GameServer.Packets.Listenable;

public class GameServerAuth
{
    public byte DesiredId { get; }
    
    public bool AcceptAlternativeId { get; }
    
    public byte HostReserved { get; }
    
    public short Port { get; }
    
    public int MaxPlayers { get; }
    
    public int Size { get; }
    
    public byte[] HexId { get; }
    
    public string[] Hosts { get; }
    
    public GameServerAuth(Packet packet)
    {
        DesiredId = packet.ReadByte();
        AcceptAlternativeId = packet.ReadByte() != 0;
        HostReserved = packet.ReadByte();
        Port = packet.ReadShort();
        MaxPlayers = packet.ReadInt();
        Size = packet.ReadInt();
        HexId = packet.ReadBytesArray(Size);
        Size = 2 * packet.ReadInt();
        Hosts = new string[Size];
        
        for (int i = 0; i < Size; i++)
        {
            Hosts[i] = packet.ReadString();
        }
    }
}