using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestShortCutReg
{
    public RequestShortCutReg(Packet packet)
    {
         int typeId = packet.ReadInt();
        _type = ShortcutType.values()[(typeId < 1) || (typeId > 6) ? 0 : typeId];
         int slot = packet.ReadInt();
         var _id = packet.ReadInt();
        readInt(); // level
        var _slot = slot % 12;
        var _page = slot / 12;
    }
}