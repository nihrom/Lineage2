using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part7;

public class RequestDuelStart
{
    public string Player;
    public int PartyDuel;

    public RequestDuelStart(Packet packet)
    {
        Player = packet.ReadString();
        PartyDuel = packet.ReadInt();
    }
}