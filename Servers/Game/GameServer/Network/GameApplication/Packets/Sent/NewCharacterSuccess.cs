using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Sent;

public class NewCharacterSuccess : Packet
{
    public record Character(
        int Race,
        int ClassId,
        int BaseStr,
        int BaseDex,
        int BaseCon,
        int BaseInt,
        int BaseWit,
        int BaseMen);
    
    public NewCharacterSuccess(List<Character> characters) 
        : base(0x17)
    {
        //TODO: реализовать заполнение пакета
        
        WriteInt(characters.Count);
        
        foreach (var character in characters)
        {
            // TODO: Unhardcode these
            WriteInt(character.Race);
            WriteInt(character.ClassId);
            WriteInt(0x46);
            WriteInt(character.BaseStr);
            WriteInt(0x0A);
            WriteInt(0x46);
            WriteInt(character.BaseDex);
            WriteInt(0x0A);
            WriteInt(0x46);
            WriteInt(character.BaseCon);
            WriteInt(0x0A);
            WriteInt(0x46);
            WriteInt(character.BaseInt);
            WriteInt(0x0A);
            WriteInt(0x46);
            WriteInt(character.BaseWit);
            WriteInt(0x0A);
            WriteInt(0x46);
            WriteInt(character.BaseMen);
            WriteInt(0x0A);
        }
    }
}