using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class AttackRequest
{
    public AttackRequest(Packet packet)
    {
        var _objectId = packet.ReadInt();
        var _originX = packet.ReadInt();
        var _originY = packet.ReadInt();
        var _originZ = packet.ReadInt();
        var _attackId = packet.ReadByte(); // 0 for simple click 1 for shift-click
    }
}