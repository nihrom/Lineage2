using System.Net.Sockets;
using Common.Network;
using GameServer.Network.GameApplication.Packets.Sent;

namespace GameServer.Network.GameApplication;

public class L2GameApplicationAvatar : L2Connection
{
    private readonly CancellationTokenSource cts = new ();
    private readonly GameApplicationPacketHandler gameApplicationPacketHandler;
    
    public L2GameApplicationAvatar(
        TcpClient tcpClient, 
        GameApplicationPacketHandler gameApplicationPacketHandler) : base(tcpClient)
    {
        this.gameApplicationPacketHandler = gameApplicationPacketHandler;
        //ScrambledKeyPair = new ScrambledKeyPair(ScrambledKeyPair.GenKeyPair());
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

    private int count = 0;
    private async Task OnReadAsync(Packet packet)
    {
        Logger.Information("OnReadAsync");
        
        await gameApplicationPacketHandler.HandleAsync(
            packet.FirstOpcode,
            packet,
            this,
            cts.Token);
        
        // if (count == 0)
        // {
        //     Logger.Information("Send NewCharacterSuccess");
        //     count++;
        //     //dist\game\data\stats\chars\baseStats\HumanFighter.xml
        //     var response = new NewCharacterSuccess(
        //         new List<NewCharacterSuccess.Character>()
        //         {
        //             new NewCharacterSuccess.Character( //ClassId.FIGHTER
        //                 0,
        //                 0,
        //                 40,
        //                 30,
        //                 43,
        //                 21,
        //                 11,
        //                 25),
        //             new NewCharacterSuccess.Character( //ClassId.MAGE
        //                 0,
        //                 10,
        //                 40,
        //                 30,
        //                 43,
        //                 21,
        //                 11,
        //                 25),
        //             new NewCharacterSuccess.Character( //ClassId.ELVEN_FIGHTER
        //                 1,
        //                 18,
        //                 40,
        //                 30,
        //                 43,
        //                 21,
        //                 11,
        //                 25),
        //             new NewCharacterSuccess.Character( //ClassId.ELVEN_MAGE
        //                 1,
        //                 25,
        //                 40,
        //                 30,
        //                 43,
        //                 21,
        //                 11,
        //                 25),
        //             new NewCharacterSuccess.Character( // ClassId.DARK_FIGHTER
        //                 2,
        //                 31,
        //                 40,
        //                 30,
        //                 43,
        //                 21,
        //                 11,
        //                 25),
        //             new NewCharacterSuccess.Character( // ClassId.DARK_MAGE
        //                 2,
        //                 38,
        //                 40,
        //                 30,
        //                 43,
        //                 21,
        //                 11,
        //                 25),
        //             new NewCharacterSuccess.Character( // ClassId.ORC_FIGHTER
        //                 3,
        //                 44,
        //                 40,
        //                 30,
        //                 43,
        //                 21,
        //                 11,
        //                 25),
        //             new NewCharacterSuccess.Character( // ClassId.ORC_MAGE
        //                 3,
        //                 49,
        //                 40,
        //                 30,
        //                 43,
        //                 21,
        //                 11,
        //                 25),
        //             new NewCharacterSuccess.Character( //ClassId.DWARVEN_FIGHTER
        //                 4,
        //                 53,
        //                 40,
        //                 30,
        //                 43,
        //                 21,
        //                 11,
        //                 25)
        //         });
        //
        //     await SendAsync(response);
        // }
        
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