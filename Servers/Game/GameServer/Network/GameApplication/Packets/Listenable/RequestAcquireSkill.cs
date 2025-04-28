using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestAcquireSkill
{
    public int Id;
    public int Level;

    public RequestAcquireSkill(Packet packet)
    {
        Id = packet.ReadInt();
        Level = packet.ReadInt();
        var _skillType = AcquireSkillType.getAcquireSkillType(packet.ReadInt());
    }
}