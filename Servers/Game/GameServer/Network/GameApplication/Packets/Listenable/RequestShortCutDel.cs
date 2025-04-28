using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestShortCutDel
{
    public RequestShortCutDel(Packet packet)
    {
         int id = packet.ReadInt();
         var _slot = id % 12;
         var _page = id / 12;
    }
}