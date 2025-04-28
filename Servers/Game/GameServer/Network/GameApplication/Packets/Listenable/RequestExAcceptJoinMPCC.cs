using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestExAcceptJoinMPCC
{
    public int Response;

    public RequestExAcceptJoinMPCC(Packet packet)
    {
        Response = packet.ReadInt();
    }
}