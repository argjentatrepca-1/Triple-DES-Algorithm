using System;
using System.IO;
using System.Security.Cryptography;

namespace Triple_DES_Algorithm
{
    public class FileHandler
    {
        // Metoda kryesore  per me procesu file-in (encrypt/decrypt)
        public static void ProcessFile(string inputFile, string outputFile, object transformer)
        {
            try
            {
                // Kontrollon a ekziston file-i hyres
                if (!File.Exists(inputFile))
                {
                    Console.WriteLine("[!] Gabim: File-i hyres nuk ekziston!");
                    return;
                }
 // Konverton transformer ne ICryptoTransform
                ICryptoTransform cryptoTransform = transformer as ICryptoTransform;

                if (cryptoTransform == null)
                {
                    Console.WriteLine("[!] Gabim: Transformer i pavlefshëm.");
                    return;
                }

                //  Hap file-in hyres dhe dales
                using (FileStream fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                                    // CryptoStream per enkriptim/dekriptim
                using (CryptoStream cryptoStream =
                    new CryptoStream(fsOutput, cryptoTransform, CryptoStreamMode.Write))
                {
                    // Kopjo te dhenat nga input ne crypto stream
                    fsInput.CopyTo(cryptoStream);
                }

                Console.WriteLine("[✔] FileHandler: Procesimi u krye me sukses!");
                Console.WriteLine($"[✔] File i ri u krijua: {outputFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[!] Gabim gjatë procesimit të file-it:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
