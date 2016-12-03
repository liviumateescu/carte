using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch11_Cryptography;

namespace Ch11_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a message you want to encrypt: ");
            string message = Console.ReadLine();
            Console.WriteLine("Enter a password: ");
            string password = Console.ReadLine();
            string cryptoText = Protector.Encrypt(message, password);
            Console.WriteLine($"Encrypted text: {cryptoText}");
            string clearText = Protector.Decrypt(cryptoText, password);
            Console.WriteLine($"Dectypted text: {clearText}");
        }
    }
}
