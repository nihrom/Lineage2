using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestMakeMacro
{
    public RequestMakeMacro(Packet packet)
    {
        var id = packet.ReadInt();
        var name = packet.ReadString();
        var desc = packet.ReadString();
        var acronym = packet.ReadString();
        int icon = packet.ReadByte();
        int count = packet.ReadByte();
        if (count > MAX_MACRO_LENGTH)
        {
            count = MAX_MACRO_LENGTH;
        }
		
         List<MacroCmd> commands = new ArrayList<>(count);
        for (int i = 0; i < count; i++)
        {
            int entry = packet.ReadByte();
            int type = packet.ReadByte(); // 1 = skill, 3 = action, 4 = shortcut
            int d1 = packet.ReadInt(); // skill or page number for shortcuts
            int d2 = packet.ReadByte();
            String command = packet.ReadString();
            _commandsLength += command.length();
            commands.add(new MacroCmd(entry, MacroType.values()[(type < 1) || (type > 6) ? 0 : type], d1, d2, command));
        }
        _macro = new Macro(id, icon, name, desc, acronym, commands);
    }
}