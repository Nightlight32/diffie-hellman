using System;
using System.Numerics;

namespace ConsoleDH
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringNumber, stringgBase, stringAliceKey, stringBobKey;
            int primeNumber, gBase, aliceSecretKey, bobSecretKey;
            do
            {
                Console.WriteLine("Enter the prime number:");
                stringNumber = Console.ReadLine();
            }
            while (!Int32.TryParse(stringNumber, out primeNumber));
            do
            {
                Console.WriteLine("Enter the base number:");
                stringgBase = Console.ReadLine();
            }
            while (!Int32.TryParse(stringgBase, out gBase));
            do
            {
                Console.WriteLine("Enter the Alice's secret key:");
                stringAliceKey = Console.ReadLine();
            }
            while (!Int32.TryParse(stringAliceKey, out aliceSecretKey));
            do
            {
                Console.WriteLine("Enter the Bob's secret key:");
                stringBobKey = Console.ReadLine();
            }
            while (!Int32.TryParse(stringBobKey, out bobSecretKey));
                   
                 //вычисляем публичный ключ Алисы
                 var A = BigInteger.ModPow(gBase, aliceSecretKey, primeNumber);
                 Console.WriteLine($"Alice public key: {A}");

                 var B = BigInteger.ModPow(gBase, bobSecretKey, primeNumber);
                 Console.WriteLine($"Bob public key: {B}");

                 //находим секретный ключ Алисы
                 var aliceSecretKeyExchanged = BigInteger.ModPow(B, aliceSecretKey, primeNumber);
                 Console.WriteLine($"Alice Secret Exchange Key: {aliceSecretKeyExchanged}");

                 var bobSecretKeyExchanged = BigInteger.ModPow(A, bobSecretKey, primeNumber);
                 Console.WriteLine($"Bob Secret Exchange Key: {bobSecretKeyExchanged}");

                 Console.ReadLine();
             
        }
    }
}
