using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part9;

public class RequestGetItemFromPet
{
    public int ObjectId;
    public int Amount;
    public int Unknown;

    public RequestGetItemFromPet(Packet packet)
    {
        ObjectId = packet.ReadInt();
        Amount = packet.ReadInt();
        Unknown = packet.ReadInt();
    }
}