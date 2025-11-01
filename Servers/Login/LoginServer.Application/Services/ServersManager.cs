using LoginServer.Domain.Models.GameServers;

namespace LoginServer.Application.Services;

public class ServersManager
{
    public IReadOnlyCollection<GameServerInfo> GetServers()
    {
        return new List<GameServerInfo>()
        {
            new GameServerInfo(
                1,
                [127, 0, 0, 1],
                3106,
                0,
                true,
                1,
                101,
                true,
                false,
                false,
                true)
        };
    }
}