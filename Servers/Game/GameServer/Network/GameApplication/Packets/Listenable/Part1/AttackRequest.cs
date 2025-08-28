using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class AttackRequest
{
    public int ObjectId;
    public int OriginX;
    public int OriginY;
    public int OriginZ;
        /// <summary>
        ///  0 for simple click 1 for shift-click
        /// </summary>
    public byte AttackId;

    public AttackRequest(Packet packet)
    {
        ObjectId = packet.ReadInt();
        OriginX = packet.ReadInt();
        OriginY = packet.ReadInt();
        OriginZ = packet.ReadInt();
        AttackId = packet.ReadByte(); 
    }
}