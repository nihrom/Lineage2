using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestExMagicSkillUseGround
{
    public int X;
    public int Y;
    public int Z;
    public int SkillId;
    public bool CtrlPressed;
    public bool ShiftPressed;

    public RequestExMagicSkillUseGround(Packet packet)
    {
        X = packet.ReadInt();
        Y = packet.ReadInt();
        Z = packet.ReadInt();
        SkillId = packet.ReadInt();
        CtrlPressed = packet.ReadInt() != 0;
        ShiftPressed = packet.ReadByte() != 0;
    }
}