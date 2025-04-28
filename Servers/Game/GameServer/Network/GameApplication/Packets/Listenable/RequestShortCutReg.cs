using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestShortCutReg
{
    public RequestShortCutReg(Packet packet)
    {
        final int typeId = readInt();
        _type = ShortcutType.values()[(typeId < 1) || (typeId > 6) ? 0 : typeId];
        final int slot = readInt();
        _id = readInt();
        readInt(); // level
        _slot = slot % 12;
        _page = slot / 12;
    }
}