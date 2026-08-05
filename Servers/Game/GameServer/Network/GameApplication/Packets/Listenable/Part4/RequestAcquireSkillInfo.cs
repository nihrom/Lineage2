using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part4;

public class RequestAcquireSkillInfo
{
    public int Id;
    public int Level;
    public int SkillTypeId;

    public RequestAcquireSkillInfo(Packet packet)
    {
        Id = packet.ReadInt();
        Level = packet.ReadInt();
        SkillTypeId = packet.ReadInt();
    }
}