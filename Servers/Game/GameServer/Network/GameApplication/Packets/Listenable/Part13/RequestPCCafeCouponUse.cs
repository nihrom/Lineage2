using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable.Part13;

public class RequestPCCafeCouponUse
{
    public string Str;

    public RequestPCCafeCouponUse(Packet packet)
    {
        Str = packet.ReadString();
    }
}