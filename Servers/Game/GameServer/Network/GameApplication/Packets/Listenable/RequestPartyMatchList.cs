using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPartyMatchList
{
    public int Roomid;
    public int Membersmax;
    public int MinLevel;
    public int MaxLevel;
    public int Loot;
    public string Roomtitle;

    public RequestPartyMatchList(Packet packet)
    {
        Roomid = packet.ReadInt();
        Membersmax = packet.ReadInt();
        MinLevel = packet.ReadInt();
        MaxLevel = packet.ReadInt();
        Loot = packet.ReadInt();
        Roomtitle = packet.ReadString();
    }
}