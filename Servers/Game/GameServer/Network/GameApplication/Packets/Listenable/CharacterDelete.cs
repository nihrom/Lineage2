using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class CharacterDelete
{
    public CharacterDelete(Packet packet)
    {
        var _charSlot = packet.ReadInt();
    }
}