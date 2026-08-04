using LoginServer.Network.GameApplication.ClientsNetwork;

namespace LoginServer.Network.GameApplication.Packets.Listenable.Handlers;

public class BaseGameApplicationHandler
{
    public required L2GameApplicationAvatar Avatar {get; init;}
}