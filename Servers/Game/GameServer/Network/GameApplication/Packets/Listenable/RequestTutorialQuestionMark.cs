using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestTutorialQuestionMark
{
    public RequestTutorialQuestionMark(Packet packet)
    {
        _number = readInt();
    }
}