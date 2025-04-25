using Common.Network;

namespace LoginServer.Network.GameServer.Packets.Listenable;

public class PlayerInGame
{
    public PlayerInGame(Packet packet)
    {
        int size = packet.ReadShort();
        
        for (int i = 0; i < size; i++)
        {
            string account = packet.ReadString();
        }
    }
}