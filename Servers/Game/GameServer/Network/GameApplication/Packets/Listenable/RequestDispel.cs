using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestDispel
{
    public RequestDispel(Packet packet)
    {
        var _skillId = packet.ReadInt();
        var _skillLevel = packet.ReadInt();
    }
}