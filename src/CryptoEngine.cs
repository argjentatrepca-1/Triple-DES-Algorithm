using System;
using System.Security.Cryptography;

namespace Triple_DES_Algorithm
{
    public class CryptoEngine
    {
        public static ICryptoTransform GetTransformer(byte[] key, byte[] iv, bool encrypt)
        {
            if (key == null || key.Length != 24)
                throw new ArgumentException("Çelësi duhet të jetë 24 bytes për TripleDES.");

            if (iv == null || iv.Length != 8)
                throw new ArgumentException("IV duhet të jetë 8 bytes për TripleDES.");

            TripleDES tripleDES = TripleDES.Create();

            tripleDES.Key = key;
            tripleDES.IV = iv;
            tripleDES.Mode = CipherMode.CBC;
            tripleDES.Padding = PaddingMode.PKCS7;

            if (encrypt)
            {
                return tripleDES.CreateEncryptor();
            }

            return tripleDES.CreateDecryptor();
        }
    }
}