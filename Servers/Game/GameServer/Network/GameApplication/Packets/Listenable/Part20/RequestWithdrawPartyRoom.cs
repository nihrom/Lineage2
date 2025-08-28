using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestWithdrawPartyRoom
{
    public int Roomid;
    public int Unk1;

    public RequestWithdrawPartyRoom(Packet packet)
    {
        Roomid = packet.ReadInt();
        Unk1 = packet.ReadInt();
    }
}