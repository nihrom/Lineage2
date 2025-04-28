using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestExAskJoinMPCC
{
    public string Name;

    public RequestExAskJoinMPCC(Packet packet)
    {
        Name = packet.ReadString();
    }
}