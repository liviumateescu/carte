using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch11_Cryptography;

namespace Ch11_Hashing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A user named Alice has been registered with Pas$$w0rd as her password.");
            var alice = Protector.Register("Alice", "Pa$$w0rd");
            Console.WriteLine($"Name: {alice.Name}");
            Console.WriteLine($"Salt: {alice.Salt}");
            Console.WriteLine($"Salted hashed password: {alice.SaltedHashedPassword}");
            Console.WriteLine();

            Console.WriteLine("Enter a username to register: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter a password to register: ");
            string password = Console.ReadLine();
            var user = Protector.Register(username, password);
            Console.WriteLine($"Name: {user.Name}");
            Console.WriteLine($"Salt: {user.Salt}");
            Console.WriteLine($"Salted hashed password: {user.SaltedHashedPassword}");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();

            bool correctPassword = false;
            while (!correctPassword)
            {
                Console.WriteLine("Enter a username to login: ");
                string loginUsername = Console.ReadLine();
                Console.WriteLine("Enter a password to login: ");
                string loginPassword = Console.ReadLine();
                correctPassword = Protector.CheckPassword(loginUsername, loginPassword);
                if (correctPassword)
                {
                    Console.WriteLine($"Correct! {loginUsername} has been logged in.");
                }
                else
                {
                    Console.WriteLine("Invalid username or password. Try again.");
                }
            }
        }
    }
}
