namespace LoginServer.Models;

public class L2Server
{
    public string Code { get; set; }
    
    public byte[] DefaultAddress { get; set; }
    
    //public ServerThread Thread { get; set; }
    
    public string Info { get; set; }
    
    public byte Id { get; set; }

    public int Port => 15; //Thread?.Port ?? 0;
    
    public byte AgeLimit => 0;

    public bool IsPvp => true;
    
    public bool Connected => true;//Thread != null ? (Thread.Connected ? (byte)1 : (byte)0) : (byte)0;

    public short CurrentPlayers => 0;// Thread?.Curp ?? (short)0;

    public short MaxPlayers => 2000; //Thread?.Maxp ?? (short)0;

    public bool IsBrackets => false;

    public bool TestMode => true;// (Thread != null) && Thread.TestMode;

    public bool GmOnly => false; //(Thread != null) && Thread.GmOnly;
    
    public byte[] GetIp()
    {
        if (DefaultAddress == null)
        {
            string ip = "127.0.0.1";

            DefaultAddress = new byte[4];
            string[] w = ip.Split('.');
            DefaultAddress[0] = byte.Parse(w[0]);
            DefaultAddress[1] = byte.Parse(w[1]);
            DefaultAddress[2] = byte.Parse(w[2]);
            DefaultAddress[3] = byte.Parse(w[3]);
        }

        return DefaultAddress;
    }
}