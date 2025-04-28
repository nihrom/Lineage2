using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestDismissPartyRoom
{
    public int Roomid;
    public int Data2;

    public RequestDismissPartyRoom(Packet packet)
    {
        Roomid = packet.ReadInt();
        Data2 = packet.ReadInt();
    }
}