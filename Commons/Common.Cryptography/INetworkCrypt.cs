namespace Common.Cryptography;

public interface INetworkCrypt
{
    void UpdateKey(byte[] blowfishKey);
    
    bool Decrypt(ref byte[] arr);
    
    byte[] Encrypt(byte[] raw);
    
    //void EnableCrypt();
}