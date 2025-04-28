using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestGMCommand
{
    public RequestGMCommand(Packet packet)
    {
        var _targetName = packet.ReadString();
        var _command = packet.ReadInt();
        // _unknown = packet.ReadInt();
    }
}