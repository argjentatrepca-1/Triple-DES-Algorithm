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
