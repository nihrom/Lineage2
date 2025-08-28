using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestUnEquipItem
{
    public int Slot;

    public RequestUnEquipItem(Packet packet)
    {
        Slot = packet.ReadInt();
    }
}