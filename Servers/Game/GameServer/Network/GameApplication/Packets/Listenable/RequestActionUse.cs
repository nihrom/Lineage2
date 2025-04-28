using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestActionUse
{
    public RequestActionUse(Packet packet)
    {
        var _actionId = packet.ReadInt();
        var _ctrlPressed = packet.ReadInt() == 1;
        var _shiftPressed = packet.ReadByte() == 1;
    }
}