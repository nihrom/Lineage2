using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestQuestAbort
{
    public int QuestId;

    public RequestQuestAbort(Packet packet)
    {
        QuestId = packet.ReadInt();
    }
}