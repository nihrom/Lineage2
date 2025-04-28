using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class MoveBackwardToLocation
{
    public int TargetX;
    public int TargetY;
    public int TargetZ;
    public int OriginX;
    public int OriginY;
    public int OriginZ;
    /// <summary>
    /// // is 0 if cursor keys are used 1 if mouse is used
    /// </summary>
    public int MovementMode;

    public MoveBackwardToLocation(Packet packet)
    {
        TargetX = packet.ReadInt();
        TargetY = packet.ReadInt();
        TargetZ = packet.ReadInt();
        OriginX = packet.ReadInt();
        OriginY = packet.ReadInt();
        OriginZ = packet.ReadInt();
        MovementMode = packet.ReadInt(); 
    }
}