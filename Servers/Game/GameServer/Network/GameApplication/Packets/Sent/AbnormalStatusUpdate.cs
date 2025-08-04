using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Sent;

public class AbnormalStatusUpdate : Packet
{
    public AbnormalStatusUpdate() : base()
    {
        //TODO: реализовать заполнение пакета
        
        // ServerPackets.ABNORMAL_STATUS_UPDATE.writeId(this, buffer);
        // buffer.writeShort(_effects.size());
        // for (BuffInfo info : _effects)
        // {
        //     if ((info != null) && info.isInUse())
        //     {
        //         final Skill skill = info.getSkill();
        //         buffer.writeInt(skill.getDisplayId());
        //         buffer.writeShort(skill.getDisplayLevel());
        //         buffer.writeInt(info.getTime());
        //     }
        // }
    }
}