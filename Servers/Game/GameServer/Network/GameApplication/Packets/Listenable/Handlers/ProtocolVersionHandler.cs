using GameServer.Network.GameApplication.Packets.Listenable.Part3;
using GameServer.Network.GameApplication.Packets.Sent;

namespace GameServer.Network.GameApplication.Packets.Listenable.Handlers;

public class ProtocolVersionHandler : BaseGameApplicationHandler, IGameApplicationHandler<ProtocolVersion>
{
    public async Task HandleAsync(ProtocolVersion request, CancellationToken ct)
    {
        // This packet is never encrypted.
        if (request.Version == -2)
        {
            // This is just a ping attempt from the new C2 client.
            // TODO: Disconnect
            //client.disconnect();
        }
        // TODO: Реализовать
        // else if (!Config.PROTOCOL_LIST.contains(_version))
        // {
        //     LOGGER_ACCOUNTING.warning("Wrong protocol version " + _version + ", " + client);
        //     client.setProtocolOk(false);
        //     client.close(new KeyPacket(client.enableCrypt(), 0));
        // }
        else
        {
            //client.setProtocolVersion(_version);
            //client.setProtocolOk(true);

            var crypt = Avatar.EnableCrypt();
            await Avatar.SendAsync(new KeyPacket(crypt.Blowfish, 1), false, ct); //client.enableCrypt(), 1));
        }
    }
}