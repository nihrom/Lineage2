using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestGMCommand
{
    public string TargetName;
    public int Command;

    public RequestGMCommand(Packet packet)
    {
        TargetName = packet.ReadString();
        Command = packet.ReadInt();
        // _unknown = packet.ReadInt();
    }
}