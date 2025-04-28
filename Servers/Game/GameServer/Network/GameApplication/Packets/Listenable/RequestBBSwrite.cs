using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestBBSwrite
{
    public string Url;
    public string Arg1;
    public string Arg2;
    public string Arg3;
    public string Arg4;
    public string Arg5;

    public RequestBBSwrite(Packet packet)
    {
        Url = packet.ReadString();
        Arg1 = packet.ReadString();
        Arg2 = packet.ReadString();
        Arg3 = packet.ReadString();
        Arg4 = packet.ReadString();
        Arg5 = packet.ReadString();
    }
}