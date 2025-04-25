using Common.Network;

namespace LoginServer.Network.GameServer.Packets.Listenable;

public class GameServerAuth
{
    public GameServerAuth(Packet packet)
    {
        var desiredId = packet.ReadByte();
        var acceptAlternativeId = packet.ReadByte() != 0;
        var hostReserved = packet.ReadByte(); // _hostReserved = readByte() != 0
        var port = packet.ReadShort();
        var maxPlayers = packet.ReadInt();
        int size = packet.ReadInt();
        var hexId = packet.ReadBytesArray(size);
        size = 2 * packet.ReadInt();
        var hosts = new string[size];
        
        for (int i = 0; i < size; i++)
        {
            hosts[i] = packet.ReadString();
        }
    }
}