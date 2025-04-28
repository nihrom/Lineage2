using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class CharacterCreate
{
    public string Name;
    public bool IsFemale;
    public int ClassId;
    public byte HairStyle;
    public byte HairColor;
    public byte Face;

    public CharacterCreate(Packet packet)
    {
        Name = packet.ReadString();
        packet.ReadInt(); // race
        IsFemale = packet.ReadInt() != 0;
        ClassId = packet.ReadInt();
        packet.ReadInt(); // _int
        packet.ReadInt(); // _str
        packet.ReadInt(); // _con
        packet.ReadInt(); // _men
        packet.ReadInt(); // _dex
        packet.ReadInt(); // _wit
        HairStyle = (byte) packet.ReadInt();
        HairColor = (byte) packet.ReadInt();
        Face = (byte) packet.ReadInt();
    }
}