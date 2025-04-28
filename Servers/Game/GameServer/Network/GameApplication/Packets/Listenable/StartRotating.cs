using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class StartRotating
{
    public StartRotating(Packet packet)
    {
        var _degree = packet.ReadInt();
        var _side = packet.ReadInt();
    }
}