using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part2;

public class CharacterRestore
{
    public int CharSlot;

    public CharacterRestore(Packet packet)
    {
        CharSlot = packet.ReadInt();
    }
}