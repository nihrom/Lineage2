using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class CharacterDelete
{
    public int CharSlot;

    public CharacterDelete(Packet packet)
    {
        CharSlot = packet.ReadInt();
    }
}