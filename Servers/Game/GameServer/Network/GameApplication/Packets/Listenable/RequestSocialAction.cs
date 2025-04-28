using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestSocialAction
{
    public RequestSocialAction(Packet packet)
    {
        var _actionId = packet.ReadInt();
    }
}