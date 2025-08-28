using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestAskJoinPartyRoom
{
    public string Name;

    public RequestAskJoinPartyRoom(Packet packet)
    {
        Name = packet.ReadString();
    }
}