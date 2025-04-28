using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestMagicSkillUse
{
    public RequestMagicSkillUse(Packet packet)
    {
        var _magicId = packet.ReadInt(); // Identifier of the used skill
        var _ctrlPressed = packet.ReadInt() != 0; // True if it's a ForceAttack : Ctrl pressed
        var _shiftPressed = packet.ReadByte() != 0; // True if Shift pressed
    }
}