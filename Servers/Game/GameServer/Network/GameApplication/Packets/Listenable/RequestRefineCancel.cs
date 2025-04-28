using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestRefineCancel
{
    public RequestRefineCancel(Packet packet)
    {
        var _targetItemObjId = packet.ReadInt();
    }
}