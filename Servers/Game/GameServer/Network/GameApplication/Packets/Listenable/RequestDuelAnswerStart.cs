using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestDuelAnswerStart
{
    public RequestDuelAnswerStart(Packet packet)
    {
        var _partyDuel = packet.ReadInt();
        var _unk1 = packet.ReadInt();
        var _response = packet.ReadInt();
    }
}