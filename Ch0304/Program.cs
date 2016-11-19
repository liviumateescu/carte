using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch0304
{
    class Program
    {
        static void Main(string[] args)
        {
            String text="1, 2, ";
            for (int i = 3; i < 100; i++)
            {
                if (i % 3 == 0)
                {
                    text += "Fizz, ";
                }
                if (i % 5 == 0)
                {
                    text += "Buzz, ";
                }
                if (i % 15 == 0)
                {
                    text += "FizzBuzz, ";
                }
                if (!((i % 5 == 0) || (i % 3 == 0) ))
                {
                    text += i.ToString();
                    text += ", ";
                }
            }
            Console.WriteLine(text);
            }
        }
    }
