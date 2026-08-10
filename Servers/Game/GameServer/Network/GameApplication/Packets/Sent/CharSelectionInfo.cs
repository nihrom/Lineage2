using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Sent;

public class CharSelectionInfo : Packet
{
    public CharSelectionInfo() : base(0x09)
    {
        //TODO: реализовать заполнение пакета

        WriteInt(0);//size); // Created character count
        WriteInt(7);//Config.MAX_CHARACTERS_NUMBER_PER_ACCOUNT); // Can prevent players from creating new characters (if 0); (if 1, the client will ask if chars may be created (0x13) Response: (0x0D) )
        WriteByte(0);// size == Config.MAX_CHARACTERS_NUMBER_PER_ACCOUNT); // if 1 can't create new char
        WriteByte(1); // 0=can't play, 1=can play free until level 85, 2=100% free play
        WriteInt(2); // if 1, Korean client
        WriteByte(0); // Balthus Knights, if 1 suggests premium account
    }
}