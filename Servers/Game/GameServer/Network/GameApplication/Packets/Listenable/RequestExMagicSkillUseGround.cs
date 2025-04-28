using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestExMagicSkillUseGround
{
    public RequestExMagicSkillUseGround(Packet packet)
    {
        var _x = packet.ReadInt();
        var _y = packet.ReadInt();
        var _z = packet.ReadInt();
        var _skillId = packet.ReadInt();
        var _ctrlPressed = packet.ReadInt() != 0;
        var _shiftPressed = packet.ReadByte() != 0;
    }
}