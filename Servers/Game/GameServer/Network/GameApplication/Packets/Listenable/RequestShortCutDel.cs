using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestShortCutDel
{
    public int Id;
    public int Slot;
    public int Page;

    public RequestShortCutDel(Packet packet)
    {
         Id = packet.ReadInt();
         Slot = Id % 12;
         Page = Id / 12;
    }
}