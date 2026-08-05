using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part13;

public class RequestPledgeExtendedInfo
{
    public RequestPledgeExtendedInfo(Packet packet)
    {
        packet.ReadString(); // name?
    }
}