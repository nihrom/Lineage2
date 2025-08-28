using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestTargetCanceld
{
    public short Unselect;

    public RequestTargetCanceld(Packet packet)
    {
        Unselect = packet.ReadShort();
    }
}