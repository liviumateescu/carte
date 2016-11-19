using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch0301
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("niciun argument");
            }
            else
            {
                Console.WriteLine("cel putin un argument");
            }

            long e = 10;
            int f;
            f = Convert.ToInt16(e);

            Console.WriteLine(System.DateTime.Now.ToString());

        A_label:
            var number = (new Random()).Next(1, 7);
            Console.WriteLine($"numar random: {number}");
            switch (number)
            {
                case 1:
                    Console.WriteLine("one");
                    break;
                case 2:
                    Console.WriteLine("two");
                    goto case 1;
                case 3:
                case 4:
                    Console.WriteLine("three of four");
                    goto case 1;
                case 5:
                    System.Threading.Thread.Sleep(500);
                    goto A_label;
                default:
                    Console.WriteLine("Default");
                    break;
            }



        }
    }
}
