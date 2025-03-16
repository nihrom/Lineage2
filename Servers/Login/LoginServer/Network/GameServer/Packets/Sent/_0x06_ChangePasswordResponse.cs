using Common.Network;

namespace LoginServer.Network.GameServer.Packets.Sent;

public class _0x06_ChangePasswordResponse : Packet
{
    public _0x06_ChangePasswordResponse(
        byte successful,
        string characterName,
        string msgToSend) : base(0x06)
    {
        // writeByte(successful); // 0 false, 1 true //TODO: Разобраться со стороны гейм сервера надо ли. Неизвестно почему не отправляется
        WriteString(characterName);
        WriteString(msgToSend);
    }
}