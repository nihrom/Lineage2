using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class DlgAnswer
{
    public int MessageId;
    public int Answer;
    public int RequesterId;

    public DlgAnswer(Packet packet)
    {
        MessageId = packet.ReadInt();
        Answer = packet.ReadInt();
        RequesterId = packet.ReadInt();
    }
}