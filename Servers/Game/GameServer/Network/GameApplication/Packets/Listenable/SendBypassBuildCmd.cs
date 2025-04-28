using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class SendBypassBuildCmd
{
    public SendBypassBuildCmd(Packet packet)
    {
        var _command = packet.ReadString();
        if (_command != null)
        {
            _command = _command.trim();
        }
    }
}