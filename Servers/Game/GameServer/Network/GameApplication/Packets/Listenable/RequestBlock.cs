using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestBlock
{
    /// <summary>
    /// // 0x00 - block, 0x01 - unblock, 0x03 - allblock, 0x04 - allunblock
    /// </summary>
    public int Type;

    public string Name;

    public RequestBlock(Packet packet)
    {
        Type = packet.ReadInt();
        if ((Type == BLOCK) || (Type == UNBLOCK))
        {
            Name = packet.ReadString();
        }
    }
}