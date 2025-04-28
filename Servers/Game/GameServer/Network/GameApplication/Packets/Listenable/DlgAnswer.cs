using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class DlgAnswer
{
    public DlgAnswer(Packet packet)
    {
        var _messageId = packet.ReadInt();
        var _answer = packet.ReadInt();
        var _requesterId = packet.ReadInt();
    }
}