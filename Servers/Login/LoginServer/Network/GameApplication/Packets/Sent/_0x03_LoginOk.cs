using Common.Network;

namespace LoginServer.Network.GameApplication.Packets.Sent;

public class _0x03_LoginOk : Packet
{
    public _0x03_LoginOk(int loginOkId1, int loginOkId2) : base(0x03)
    {
        WriteInt(loginOkId1, loginOkId2);
        WriteIntArray(new int[2]);
        WriteInt(0x000003ea);
        WriteIntArray(new int[3]);
        WriteByteArray(new byte[16]);
    }
}