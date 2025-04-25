using Common.Network;

namespace LoginServer.Network.GameServer.Packets.Listenable;

public class BlowFishKey
{
    public BlowFishKey(Packet packet)
    {
        int size = packet.ReadInt();
        byte[] tempKey = packet.ReadBytesArray(size);
    }
}