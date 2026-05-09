using System;
using System.Security.Cryptography;

namespace Triple_DES_Algorithm
{
    public class CryptoEngine
    {
        public static ICryptoTransform GetTransformer(byte[] key, byte[] iv, bool encrypt)
        {
            TripleDES tripleDES = TripleDES.Create();

            tripleDES.Key = key;
            tripleDES.IV = iv;
            tripleDES.Mode = CipherMode.CBC;
            tripleDES.Padding = PaddingMode.PKCS7;

            if (encrypt)
            {
                return tripleDES.CreateEncryptor();
            }
            else
            {
                return tripleDES.CreateDecryptor();
            }
        }
    }
}