using Common.Network;

namespace GameServer.Network.GameApplication.Packets.Listenable;

public class RequestMakeMacro
{
    public RequestMakeMacro(Packet packet)
    {
        final int id = readInt();
        final String name = readString();
        final String desc = readString();
        final String acronym = readString();
        final int icon = readByte();
        int count = readByte();
        if (count > MAX_MACRO_LENGTH)
        {
            count = MAX_MACRO_LENGTH;
        }
		
        final List<MacroCmd> commands = new ArrayList<>(count);
        for (int i = 0; i < count; i++)
        {
            final int entry = readByte();
            final int type = readByte(); // 1 = skill, 3 = action, 4 = shortcut
            final int d1 = readInt(); // skill or page number for shortcuts
            final int d2 = readByte();
            final String command = readString();
            _commandsLength += command.length();
            commands.add(new MacroCmd(entry, MacroType.values()[(type < 1) || (type > 6) ? 0 : type], d1, d2, command));
        }
        _macro = new Macro(id, icon, name, desc, acronym, commands);
    }
}