using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestActionUse
{
    public int ActionId;
    public bool CtrlPressed;
    public bool ShiftPressed;

    public RequestActionUse(Packet packet)
    {
        ActionId = packet.ReadInt();
        CtrlPressed = packet.ReadInt() == 1;
        ShiftPressed = packet.ReadByte() == 1;
    }
}