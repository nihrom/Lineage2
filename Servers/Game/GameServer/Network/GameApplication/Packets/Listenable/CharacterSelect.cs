using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class CharacterSelect
{
    public int CharSlot;
    public short Unk1;
    public int Unk2;
    public int Unk3;
    public int Unk4;

    public CharacterSelect(Packet packet)
    {
        CharSlot = packet.ReadInt();
        Unk1 = packet.ReadShort();
        Unk2 = packet.ReadInt();
        Unk3 = packet.ReadInt();
        Unk4 = packet.ReadInt();
    }
}