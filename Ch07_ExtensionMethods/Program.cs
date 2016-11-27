using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Packt.CS6;

namespace Ch07_ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            string email1 = "pamela@test.com";
            string email2 = "ian&test.com";
            Console.WriteLine($"{email1} is valid email adress : {MyExtensions.IsValidEmail(email1)}.");
            Console.WriteLine($"{email2} is valid email adress : {MyExtensions.IsValidEmail(email2)}.");

            Console.WriteLine($"{email1} is valid email adress : {email1.IsValidEmail()}.");
            Console.WriteLine($"{email2} is valid email adress : {email2.IsValidEmail()}.");
        }
    }
}
