using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class UseItem
{
    public int ObjectId;
    public bool CtrlPressed;

    public UseItem(Packet packet)
    {
        ObjectId = packet.ReadInt();
        CtrlPressed = packet.ReadInt() != 0;
    }
}