using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class SendBypassBuildCmd
{
    public string? Command;

    public SendBypassBuildCmd(Packet packet)
    {
        Command = packet.ReadString();

        Command = Command?.Trim();
    }
}