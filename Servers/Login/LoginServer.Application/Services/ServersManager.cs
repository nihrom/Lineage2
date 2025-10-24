using LoginServer.Domain.Models.GameServers;

namespace LoginServer.Application.Services;

public class ServersManager
{
    public IReadOnlyCollection<GameServerInfo> GetServers()
    {
        return new List<GameServerInfo>()
        {
            new GameServerInfo(
                200,
                [127, 0, 0, 1],
                3106,
                0,
                true,
                10,
                10000,
                true,
                false,
                true,
                true)
        };
    }
}