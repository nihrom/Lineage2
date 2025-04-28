using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestDuelAnswerStart
{
    public int PartyDuel;
    public int Unk1;
    public int Response;

    public RequestDuelAnswerStart(Packet packet)
    {
        PartyDuel = packet.ReadInt();
        Unk1 = packet.ReadInt();
        Response = packet.ReadInt();
    }
}