using Common.Network;

namespace LoginServer.Network.GameServer.Packets.Listenable;

public class ServerStatus
{
    public ServerStatus(Packet packet)
    {
        int size = packet.ReadInt();
        
        for (int i = 0; i < size; i++)
        {
            int type = packet.ReadInt();
            int value = packet.ReadInt();
        }
    }
}