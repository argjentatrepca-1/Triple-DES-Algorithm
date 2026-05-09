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
