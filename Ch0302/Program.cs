using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch0302
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse("27");
            DateTime birthday = DateTime.Parse("4 July 1980");
            Console.WriteLine($"I was born {age} years ago.");
            Console.WriteLine($"My burthday is {birthday}.");
            Console.WriteLine($"My burthday is {birthday:D}.");
        }
    }
}
