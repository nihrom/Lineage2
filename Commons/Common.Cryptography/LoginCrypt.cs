﻿namespace Common.Cryptography;

public class LoginCrypt : INetworkCrypt
{
    private byte[] key =
        { 0x6b, 0x60, 0xcb, 0x5b, 0x82, 0xce, 0x90, 0xb1, 0xcc, 0x2b, 0x6c, 0x55, 0x6c, 0x6c, 0x6c, 0x6c };
    
    private bool updatedKey;

    private readonly Random random = new();
    private readonly BlowfishCipher cipher;


    public LoginCrypt()
    {
        cipher = new BlowfishCipher(key);
    }

    public void UpdateKey(byte[] blowfishKey)
    {
        key = blowfishKey;
    }

    public bool Decrypt(ref byte[] arr)
    {
        return Decrypt(ref arr, 0, arr.Length);
    }

    public byte[] Encrypt(byte[] raw)
    {
        return Encrypt(raw, 0, raw.Length);
    }

    public bool Decrypt(ref byte[] data, int offset, int size)
    {
        cipher.decipher(data, offset, size);

        return VerifyCheckSum(data, offset, size);
    }

    public byte[] Encrypt(byte[] data, int offset, int size)
    {
        size += 4;

        if (!updatedKey)
        {
            size += 4;
            size += 8 - size % 8;
            Array.Resize(ref data, size);
            EncXorPass(data, offset, size, random.Next());
            cipher.cipher(data, offset, size);
            cipher.updateKey(key);
            updatedKey = true;
        }
        else
        {
            size += 8 - size % 8;
            Array.Resize(ref data, size);
            AppendChecksum(data, offset, size);
            cipher.cipher(data, offset, size);
        }

        return data;
    }

    private bool VerifyCheckSum(byte[] data, int offset, int size)
    {
        if ((size & 3) != 0 || size <= 4)
            return false;

        long checkSum = 0;
        var count = size - 4;
        long check;
        int i;

        for (i = offset; i < count; i += 4)
        {
            check = data[i] & 255;
            check |= (data[i + 1] << 8) & 65280L;
            check |= (data[i + 2] << 0x10) & 16711680L;
            check |= (data[i + 3] << 0x18) & 4278190080L;

            checkSum ^= check;
        }

        check = data[i] & 255;
        check |= (data[i + 1] << 8) & 65280L;
        check |= (data[i + 2] << 0x10) & 16711680L;
        check |= (data[i + 3] << 0x18) & 4278190080L;

        return checkSum == 0;
    }

    public static void AppendChecksum(byte[] raw, int offset, int size)
    {
        long checkSum = 0;
        var count = size - 4;
        long ecx;
        int i;

        for (i = offset; i < count; i += 4)
        {
            ecx = raw[i] & 0xff;
            ecx |= (raw[i + 1] << 0x08) & 0xff00L;
            ecx |= (raw[i + 2] << 0x10) & 0xff0000L;
            ecx |= (raw[i + 3] << 0x18) & 0xff000000L;

            checkSum ^= ecx;
        }

        ecx = raw[i] & 0xff;
        ecx |= (raw[i + 1] << 0x08) & 0xff00L;
        ecx |= (raw[i + 2] << 0x10) & 0xff0000L;
        ecx |= (raw[i + 3] << 0x18) & 0xff000000L;

        raw[i] = (byte)(checkSum & 0xff);
        raw[i + 1] = (byte)((checkSum >> 0x08) & 0xff);
        raw[i + 2] = (byte)((checkSum >> 0x10) & 0xff);
        raw[i + 3] = (byte)((checkSum >> 0x18) & 0xff);
    }

    public static void EncXorPass(byte[] raw, int offset, int size, int key)
    {
        var stop = size - 8;
        var pos = 4 + offset;
        var ecx = key;

        while (pos < stop)
        {
            var edx = raw[pos] & 0xFF;
            edx |= (raw[pos + 1] & 0xFF) << 8;
            edx |= (raw[pos + 2] & 0xFF) << 16;
            edx |= (raw[pos + 3] & 0xFF) << 24;

            ecx += edx;

            edx ^= ecx;

            raw[pos++] = (byte)(edx & 0xFF);
            raw[pos++] = (byte)((edx >> 8) & 0xFF);
            raw[pos++] = (byte)((edx >> 16) & 0xFF);
            raw[pos++] = (byte)((edx >> 24) & 0xFF);
        }

        raw[pos++] = (byte)(ecx & 0xFF);
        raw[pos++] = (byte)((ecx >> 8) & 0xFF);
        raw[pos++] = (byte)((ecx >> 16) & 0xFF);
        raw[pos++] = (byte)((ecx >> 24) & 0xFF);
    }
}