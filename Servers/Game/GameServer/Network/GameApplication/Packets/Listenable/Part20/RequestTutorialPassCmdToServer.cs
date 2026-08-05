using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part20;

public class RequestTutorialPassCmdToServer
{
    public string Bypass;

    public RequestTutorialPassCmdToServer(Packet packet)
    {
        Bypass = packet.ReadString();
    }
}