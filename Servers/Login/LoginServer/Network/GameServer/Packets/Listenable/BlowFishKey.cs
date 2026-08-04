using Common.Network;

namespace LoginServer.Network.GameServer.Packets.Listenable;

public class BlowFishKey
{
    public byte[] TempKey { get; }

    public BlowFishKey(Packet packet)
    {
        int size = packet.ReadInt();
        TempKey = packet.ReadBytesArray(size);
    }
}