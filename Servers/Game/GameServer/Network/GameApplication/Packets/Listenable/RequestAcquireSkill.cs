using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestAcquireSkill
{
    public RequestAcquireSkill(Packet packet)
    {
        var _id = packet.ReadInt();
        var _level = packet.ReadInt();
        var _skillType = AcquireSkillType.getAcquireSkillType(packet.ReadInt());
    }
}