using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestDuelStart
{
    public RequestDuelStart(Packet packet)
    {
        var _player = packet.ReadString();
        var _partyDuel = packet.ReadInt();
    }
}