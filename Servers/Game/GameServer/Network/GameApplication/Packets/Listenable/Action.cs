using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class Action
{
    public int ObjectId { get; }
    
    public int OriginX { get; }
    
    public int OriginY { get; }
    
    public int OriginZ { get; }
    
    /// <summary>
    /// Action identifier : 0-Simple click, 1-Shift click
    /// </summary>
    public byte ActionId;

    public Action(Packet packet)
    {
        ObjectId = packet.ReadInt();
        OriginX = packet.ReadInt();
        OriginY = packet.ReadInt();
        OriginZ = packet.ReadInt();
        ActionId = packet.ReadByte();
    }
}