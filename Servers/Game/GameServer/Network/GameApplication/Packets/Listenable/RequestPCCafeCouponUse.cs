using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestPCCafeCouponUse
{
    public string Str;

    public RequestPCCafeCouponUse(Packet packet)
    {
        Str = packet.ReadString();
    }
}