using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part7;

public class RequestExAcceptJoinMPCC
{
    public int Response;

    public RequestExAcceptJoinMPCC(Packet packet)
    {
        Response = packet.ReadInt();
    }
}