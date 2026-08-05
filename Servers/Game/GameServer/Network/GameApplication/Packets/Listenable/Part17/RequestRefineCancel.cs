using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part17;

public class RequestRefineCancel
{
    public int TargetItemObjId;

    public RequestRefineCancel(Packet packet)
    {
        TargetItemObjId = packet.ReadInt();
    }
}