using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestRefineCancel
{
    public int TargetItemObjId;

    public RequestRefineCancel(Packet packet)
    {
        TargetItemObjId = packet.ReadInt();
    }
}