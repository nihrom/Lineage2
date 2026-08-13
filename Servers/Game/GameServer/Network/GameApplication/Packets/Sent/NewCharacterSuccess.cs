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
        : base(0x0D)
    {
        //TODO: реализовать заполнение пакета
        
        WriteInt(characters.Count);
        
        foreach (var character in characters)
        {
            // TODO: Unhardcode these
            WriteInt(character.Race);
            WriteInt(character.ClassId);
            WriteInt(99);
            WriteInt(character.BaseStr);
            WriteInt(1);
            WriteInt(99);
            WriteInt(character.BaseDex);
            WriteInt(1);
            WriteInt(99);
            WriteInt(character.BaseCon);
            WriteInt(1);
            WriteInt(99);
            WriteInt(character.BaseInt);
            WriteInt(1);
            WriteInt(99);
            WriteInt(character.BaseWit);
            WriteInt(1);
            WriteInt(99);
            WriteInt(character.BaseMen);
            WriteInt(1);
        }
    }
}