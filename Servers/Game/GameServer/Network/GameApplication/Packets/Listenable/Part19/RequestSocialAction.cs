using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestSocialAction
{
    public int ActionId;

    public RequestSocialAction(Packet packet)
    {
        ActionId = packet.ReadInt();
    }
}