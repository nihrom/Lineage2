using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestMagicSkillUse
{
    /// <summary>
    /// Identifier of the used skill
    /// </summary>
    public int MagicId;

    /// <summary>
    /// True if it's a ForceAttack : Ctrl pressed
    /// </summary>
    public bool CtrlPressed;

    /// <summary>
    /// True if Shift pressed
    /// </summary>
    public bool ShiftPressed;

    public RequestMagicSkillUse(Packet packet)
    {
        MagicId = packet.ReadInt(); 
        CtrlPressed = packet.ReadInt() != 0;
        ShiftPressed = packet.ReadByte() != 0;
    }
}