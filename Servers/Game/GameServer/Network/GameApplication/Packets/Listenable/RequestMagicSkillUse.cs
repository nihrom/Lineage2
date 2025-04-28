using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestMagicSkillUse
{
    public RequestMagicSkillUse(Packet packet)
    {
        _magicId = readInt(); // Identifier of the used skill
        _ctrlPressed = readInt() != 0; // True if it's a ForceAttack : Ctrl pressed
        _shiftPressed = readByte() != 0; // True if Shift pressed
    }
}