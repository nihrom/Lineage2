using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class SendBypassBuildCmd
{
    public SendBypassBuildCmd(Packet packet)
    {
        _command = readString();
        if (_command != null)
        {
            _command = _command.trim();
        }
    }
}