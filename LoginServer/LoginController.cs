using Common.Cryptography;
using Common.Network;

namespace LoginServer;

public class LoginController
{
    private readonly L2Connection l2Connection;

    private int sessionId;
    private ScrambledKeyPair scrambledKeyPair;
    private readonly byte[] blowfish = new byte[16];

    public LoginController(L2Connection l2Connection)
    {
        this.l2Connection = l2Connection;
        l2Connection.ReceivedPacket += OnReadAsync;

        var random = new Random();

        sessionId = random.Next();
        scrambledKeyPair = new ScrambledKeyPair(ScrambledKeyPair.GenKeyPair()); //TODO: Возможно нужен пул ключей
        random.NextBytes(blowfish); //TODO: Возможно нужен пул ключей
    }

    public async Task Init()
    {
        var packet = PacketBuilder.Init(
            sessionId, 
            scrambledKeyPair.scrambledModulus,
            blowfish);

        await l2Connection.SendAsync(packet);
    }

    public void AuthGameGuard()
    {
        
    }
    
    public void OnReadAsync(Packet p)
    {

    }
}