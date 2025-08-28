using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestShortCutReg
{
    public int TypeId;
    public int Id;
    public int Slot;
    public int Page;
    
    public RequestShortCutReg(Packet packet)
    {
         TypeId = packet.ReadInt();
         var slot = packet.ReadInt();
         Id = packet.ReadInt();
         packet.ReadInt(); // level
        Slot = slot % 12;
        Page = slot / 12;
    }
}