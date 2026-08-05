using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part20;

public class RequestTutorialQuestionMark
{
    public int Number;

    public RequestTutorialQuestionMark(Packet packet)
    {
        Number = packet.ReadInt();
    }
}