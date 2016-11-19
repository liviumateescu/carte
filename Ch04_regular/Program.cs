using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Ch04_regular
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter yuor age");
            string input = Console.ReadLine();
            Regex ageChecker = new Regex(@"^\d+$");
            if (ageChecker.IsMatch(input))
            {
                Console.WriteLine("corect");
            }
            else
            {
                Console.WriteLine($"this is not a valid age: {input}");
            }
        }
    }
}
