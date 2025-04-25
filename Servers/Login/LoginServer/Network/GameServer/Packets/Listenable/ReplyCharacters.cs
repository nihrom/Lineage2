using Common.Network;

namespace LoginServer.Network.GameServer.Packets.Listenable;

public class ReplyCharacters
{
    public ReplyCharacters(Packet packet)
    {
        string account = packet.ReadString();
        int chars = packet.ReadByte();
        int charsToDel = packet.ReadByte();
        long[] charsList = new long[charsToDel];
        
        for (int i = 0; i < charsToDel; i++)
        {
            charsList[i] = packet.ReadLong();
        }
    }
}