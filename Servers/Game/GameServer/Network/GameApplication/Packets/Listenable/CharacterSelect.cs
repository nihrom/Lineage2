using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class CharacterSelect
{
    public CharacterSelect(Packet packet)
    {
        var _charSlot = packet.ReadInt();
        var _unk1 = packet.ReadShort();
        var _unk2 = packet.ReadInt();
        var _unk3 = packet.ReadInt();
        var _unk4 = packet.ReadInt();
    }
}