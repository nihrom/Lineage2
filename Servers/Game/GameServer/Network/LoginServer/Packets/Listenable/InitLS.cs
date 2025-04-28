using Common.Network;

namespace GameServer.Network.LoginServer.Packets.Listenable;

public class InitLS
{
    public int Rev { get; }
    
    public byte[] Key { get; }

    public InitLS(Packet packet)
    {
        Rev = packet.ReadInt();
         int size = packet.ReadInt();
        Key = packet.ReadBytesArray(size);
    }
}