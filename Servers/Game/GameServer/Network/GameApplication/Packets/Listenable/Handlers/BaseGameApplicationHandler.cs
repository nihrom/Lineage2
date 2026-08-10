namespace GameServer.Network.GameApplication.Packets.Listenable.Handlers;

public abstract class BaseGameApplicationHandler
{
    public required L2GameApplicationAvatar Avatar {get; init;}
}