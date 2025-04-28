using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestGMCommand
{
    public RequestGMCommand(Packet packet)
    {
        _targetName = readString();
        _command = readInt();
        // _unknown = readInt();
    }
}