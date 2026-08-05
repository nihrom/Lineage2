using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part9;

public class RequestGiveNickName
{
    public string Target;
    public string Title;

    public RequestGiveNickName(Packet packet)
    {
        Target = packet.ReadString();
        Title = packet.ReadString();
    }
}