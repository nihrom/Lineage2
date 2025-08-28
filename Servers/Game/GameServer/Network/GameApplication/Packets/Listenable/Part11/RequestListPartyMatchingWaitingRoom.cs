using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestListPartyMatchingWaitingRoom
{
    public int Page;
    public int MinLevel;
    public int MaxLevel;
    public int Mode;

    public RequestListPartyMatchingWaitingRoom(Packet packet)
    {
        Page = packet.ReadInt();
        MinLevel = packet.ReadInt();
        MaxLevel = packet.ReadInt();
        Mode = packet.ReadInt();
    }
}