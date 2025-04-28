using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class CharacterRestore
{
    public CharacterRestore(Packet packet)
    {
        var _charSlot = packet.ReadInt();
    }
}