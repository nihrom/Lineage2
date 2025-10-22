using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;

namespace Common.Cryptography;

public class ScrambledKeyPair
{
    private AsymmetricCipherKeyPair pair;
    private AsymmetricKeyParameter publicKey;
    public byte[] scrambledModulus;
    public AsymmetricKeyParameter privateKey;
    
    public ScrambledKeyPair(AsymmetricCipherKeyPair pPair)
    {
        pair = pPair;
        publicKey = pPair.Public;
        scrambledModulus = ScrambleModulus((publicKey as RsaKeyParameters).Modulus);
        privateKey = pPair.Private;
    }
    
    public static AsymmetricCipherKeyPair GenKeyPair()
    {
        var random = new SecureRandom();
        
        var generationParameters = new RsaKeyGenerationParameters(
            BigInteger.ValueOf(65537L),
            random, 
            1024, 
            10);
        
        var keyPairGenerator = new RsaKeyPairGenerator();
        keyPairGenerator.Init(generationParameters);
        return keyPairGenerator.GenerateKeyPair();
    }

    public byte[] ScrambleModulus(BigInteger modulus)
    {
        byte[] sourceArray = modulus.ToByteArray();
        
        if (sourceArray.Length == 129 && sourceArray[0] == (byte) 0)
        {
            byte[] destinationArray = new byte[128];
            Array.Copy(sourceArray, 1, destinationArray, 0, 128);
            sourceArray = destinationArray;
        }
        
        for (int index = 0; index < 4; index++)
        {
            byte num = sourceArray[index];
            
            sourceArray[index] = sourceArray[77 + index];
            
            sourceArray[77 + index] = num;
        }
        
        for (int index = 0; index < 64; index++)
            sourceArray[index] = (byte)(sourceArray[index] ^ sourceArray[64 + index]);
        
        for (int index = 0; index < 4; index++)
            sourceArray[13 + index] = (byte)(sourceArray[13 + index] ^ sourceArray[52 + index]);
        
        for (int index = 0; index < 64; index++)
            sourceArray[64 + index] = (byte)(sourceArray[64 + index] ^ sourceArray[index]);
        
        return sourceArray;
    }
}