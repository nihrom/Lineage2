using Common.Network;

namespace GameServer.Network.LoginServer.Packets.Listenable;

public class ChangePasswordResponse
{
    public string Character { get; }
    
    public string MsgToSend { get; }

    public ChangePasswordResponse(Packet packet)
    {
        // boolean isSuccessful = readByte() > 0;
        Character = packet.ReadString();
        MsgToSend = packet.ReadString();
    }
}