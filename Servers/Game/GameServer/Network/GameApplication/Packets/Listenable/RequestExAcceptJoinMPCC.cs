using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestExAcceptJoinMPCC
{
    public RequestExAcceptJoinMPCC(Packet packet)
    {
        _response = readInt();
    }
}