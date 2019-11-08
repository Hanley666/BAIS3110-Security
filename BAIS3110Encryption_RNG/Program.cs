using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BAIS3110Encryption_RNG
{
    class Program
    {
        static void Main(string[] args)
        {
            #region RNG & Base64Encoding/Decoding
            rngdemo();
            #endregion

            #region Hash & Salt
            hashdemo();
            #endregion

            #region DPAPI
            PayloadDemo();
            #endregion
        }

        private static void PayloadDemo()
        {
            //get the path to %LOCALAPPDATA%\myapp-keys
            var destFolder = Path.Combine(
                System.Environment.GetEnvironmentVariable("LOCALAPPDATA"),
                "myapp-keys");

            // Instantiate the data protection system at this folder
            var dataProtectionProvider = DataProtectionProvider.Create(new DirectoryInfo(destFolder));

            var protector = dataProtectionProvider.CreateProtector("Program.No-DI");
            Console.Write("Enter Input:");
            var input = Console.ReadLine();

            //Protect the Payload
            var protectedPayload = protector.Protect(input);
            Console.WriteLine($"Protect Returned: {protectedPayload}");

            //UnProtect Payload
            var unProtectedPayload = protector.Unprotect(protectedPayload);
            Console.WriteLine($"Unprotected Retured: {unProtectedPayload}");

            Console.WriteLine();
            Console.WriteLine("Press any Key...");
            Console.ReadKey();
        }

        private static void hashdemo()
        {
            Console.Write("Enter a Password");
            string password = Console.ReadLine();

            //Generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            Console.WriteLine($"Salt: { Convert.ToBase64String(salt)}");

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            Console.WriteLine($"Hashed: {hashed}");
        }

        private static void rngdemo()
        {
            const int Number = 10;
            byte[] RandomNumberArray = new byte[Number];

            Stopwatch stopwatch = Stopwatch.StartNew();

            RNGCryptoServiceProvider rngCSP = new RNGCryptoServiceProvider();
            rngCSP.GetBytes(RandomNumberArray);

            string Base64EncodedString;
            Base64EncodedString = Convert.ToBase64String(RandomNumberArray);

            Console.WriteLine("Base64Encoded String: " + Base64EncodedString);


            byte[] data = Convert.FromBase64String(Base64EncodedString);
            string Base64DecodedString = Encoding.UTF8.GetString(data);

            Console.WriteLine("Decoded Base64: " + BitConverter.ToString(data));

            stopwatch.Stop();
            Console.WriteLine("Creating " + Number + "Random Numbers took " + stopwatch.Elapsed);

            for (int index = 0; index < RandomNumberArray.Length; index++)
            {
                byte roll = (byte)(RandomNumberArray[index] % 1000);

                Console.WriteLine(roll);
            }
        }
    }
}
