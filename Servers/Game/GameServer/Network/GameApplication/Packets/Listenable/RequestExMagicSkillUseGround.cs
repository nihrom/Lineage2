using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestExMagicSkillUseGround
{
    public RequestExMagicSkillUseGround(Packet packet)
    {
        _x = readInt();
        _y = readInt();
        _z = readInt();
        _skillId = readInt();
        _ctrlPressed = readInt() != 0;
        _shiftPressed = readByte() != 0;
    }
}