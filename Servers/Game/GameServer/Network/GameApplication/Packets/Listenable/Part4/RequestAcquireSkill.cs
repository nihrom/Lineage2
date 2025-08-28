using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestAcquireSkill
{
    public int Id;
    public int Level;
    public int SkillTypeId;

    public RequestAcquireSkill(Packet packet)
    {
        Id = packet.ReadInt();
        Level = packet.ReadInt();
        SkillTypeId = packet.ReadInt();
    }
}