using Common.Network;

namespace LoginServer.Network.GameServer.Packets.Listenable;

public class PlayerInGame
{
    public string Account { get; }

    public PlayerInGame(Packet packet)
    {
        int size = packet.ReadShort();
        
        for (int i = 0; i < size; i++)
        {
            Account = packet.ReadString();
        }
    }
}