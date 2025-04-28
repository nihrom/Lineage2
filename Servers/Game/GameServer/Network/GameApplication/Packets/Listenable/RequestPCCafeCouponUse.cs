using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPCCafeCouponUse
{
    public RequestPCCafeCouponUse(Packet packet)
    {
        var _str = packet.ReadString();
    }
}