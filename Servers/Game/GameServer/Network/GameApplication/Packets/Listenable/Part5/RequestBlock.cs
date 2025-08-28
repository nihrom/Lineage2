using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestBlock
{
    private static int BLOCK = 0;
    private static int UNBLOCK = 1;
    private static int BLOCKLIST = 2;
    private static int ALLBLOCK = 3;
    private static int ALLUNBLOCK = 4;
    
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