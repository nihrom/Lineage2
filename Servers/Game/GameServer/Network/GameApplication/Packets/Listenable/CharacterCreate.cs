using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class CharacterCreate
{
    public CharacterCreate(Packet packet)
    {
        var _name = packet.ReadString();
        packet.ReadInt(); // race
        var _isFemale = packet.ReadInt() != 0;
        var _classId = packet.ReadInt();
        packet.ReadInt(); // _int
        packet.ReadInt(); // _str
        packet.ReadInt(); // _con
        packet.ReadInt(); // _men
        packet.ReadInt(); // _dex
        packet.ReadInt(); // _wit
        var _hairStyle = (byte) packet.ReadInt();
        var _hairColor = (byte) packet.ReadInt();
        var _face = (byte) packet.ReadInt();
    }
}