using System.Net.Sockets;
using Common.Network;

namespace GameServer.Network.GameApplication.ClientsNetwork;

public class L2GameApplicationAvatar : L2Connection
{
    private readonly PacketHandlersBuilder packetHandlersBuilder;
    private readonly CancellationTokenSource cts = new ();
    
    public L2GameApplicationAvatar(
        TcpClient tcpClient,
        PacketHandlersBuilder packetHandlersBuilder) : base(tcpClient)
    {
        //ScrambledKeyPair = new ScrambledKeyPair(ScrambledKeyPair.GenKeyPair());
        this.packetHandlersBuilder = packetHandlersBuilder;
        ReceivedPacket += OnReadAsync;
    }
    
    public async Task Init()
    {
        // await SendAsync(
        //     new _0x00_Init(
        //         SessionId,
        //         ScrambledKeyPair.scrambledModulus,
        //         Crypt.Blowfish),
        //     false);
        
        _ = Task
            .Run(() => ReadAsync(cts.Token))
            .ContinueWith(
                _ =>
                {
                    Logger.Information("Client disposed");
                    Dispose();
                });
    }
    
    private async Task OnReadAsync(Packet packet)
    {
        // switch (packet.FirstOpcode)
        // {
        //     case 0x00:
        //     {
        //         var requestPacket = new RequestAuthLogin(packet);
        //         var handler = packetHandlersBuilder
        //             .Get<RequestAuthLoginHandler>();
        //         handler.Avatar = this;
        //         await handler.Handle(requestPacket);
        //     }
        //     default: break;
        // }
    }
}