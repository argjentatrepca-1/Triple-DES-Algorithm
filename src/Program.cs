using System;
using System.Reflection;
using System.Text;
using System.Security.Cryptography;
namespace Triple_DES_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("==============================================");
                Console.WriteLine("   PROJEKTI: TRIPLE-DES-ALGORITHM (3DES)   ");
                Console.WriteLine("==============================================\n");

                
                Console.Write("➤ Shkruani rrugën e fajllit: ");
                string path = Console.ReadLine() ?? "";

                Console.Write("➤ Shkruani çelësin (16 karaktere): ");
                string keyInput = Console.ReadLine() ?? "";
                
                
                byte[] rawKey = Encoding.UTF8.GetBytes(keyInput.PadRight(16).Substring(0, 16));

                byte[] key = new byte[24];

                Array.Copy(rawKey, 0, key, 0, 16);
                Array.Copy(rawKey, 0, key, 16, 8);
                byte[] iv = Encoding.UTF8.GetBytes("87654321"); 

                
                Console.WriteLine("\nZgjidhni veprimin:");
                Console.WriteLine("1. Enkripto");
                Console.WriteLine("2. Dekripto");
                Console.Write("Zgjedhja juaj (1 ose 2): ");
                
                string zgjedhja = Console.ReadLine() ?? "";
                bool encrypt = (zgjedhja == "1");

                if (zgjedhja != "1" && zgjedhja != "2")
                {
                    Console.WriteLine("\n[!] Gabim: Zgjedhje e pavlefshme.");
                    return;
                }

                string resultFile = encrypt ? path + ".enc" : path.Replace(".enc", "_decrypted.txt");

                Console.WriteLine("\n--- KONTROLLI I MODULEVE (Integration Status) ---");

                
                object? transformer = null;
                Type? cryptoType = typeof(Triple_DES_Algorithm.CryptoEngine);

                if (cryptoType != null)
                {
                    MethodInfo? getTransMethod = cryptoType.GetMethod("GetTransformer");
                    if (getTransMethod != null)
                    {
                        transformer = getTransMethod.Invoke(null, new object[] { key, iv, encrypt });
                        Console.WriteLine("[✔] Moduli 'CryptoEngine' u gjet.");
                    }
                }
                else
                {
                    Console.WriteLine("[ ] CryptoEngine: Duke pritur implementimin nga CryptoEngine.cs ...");
                }

                
                Type? fileHandlerType = typeof(Triple_DES_Algorithm.FileHandler);

                if (fileHandlerType != null && transformer != null)
                {
                    MethodInfo? processMethod = fileHandlerType.GetMethod("ProcessFile");
                    if (processMethod != null)
                    {
                        processMethod.Invoke(null, new object[] { path, resultFile, transformer });
                        Console.WriteLine("[✔] Moduli 'FileHandler' u gjet. Procesi përfundoi!");
                        Console.WriteLine($"\n[INFO] Fajlli i ri është krijuar: {resultFile}");
                    }
                }
                 
                else 
                {
                    Console.WriteLine("[!] Gabim: Nuk mund të nisë procesimi pa të dy modulet.");
                }

                Console.WriteLine("--------------------------------------------------\n");
                Console.WriteLine("Shtypni çdo tast për të mbyllur programin...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                
        
                Console.WriteLine($"\n[gabim] {ex.Message}");
                Console.ReadKey();
            }
        }
    }
}