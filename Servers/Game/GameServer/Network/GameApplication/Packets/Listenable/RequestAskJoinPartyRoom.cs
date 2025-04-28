using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestAskJoinPartyRoom
{
    public RequestAskJoinPartyRoom(Packet packet)
    {
        var _name = packet.ReadString();
    }
}