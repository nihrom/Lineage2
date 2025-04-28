using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestBBSwrite
{
    public RequestBBSwrite(Packet packet)
    {
        var _url = packet.ReadString();
        var _arg1 = packet.ReadString();
        var _arg2 = packet.ReadString();
        var _arg3 = packet.ReadString();
        var _arg4 = packet.ReadString();
        var _arg5 = packet.ReadString();
    }
}