namespace Common.Cryptography;

public interface INetworkCrypt
{
    byte[] BlowfishKey { get; }
    void Decrypt(byte[] arr);
    void Encrypt(byte[] raw);
    void EnableCrypt();
}