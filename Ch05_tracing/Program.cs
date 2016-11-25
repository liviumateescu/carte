using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Ch05_tracing
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine("debug trace says hello");
            Trace.WriteLine("trace trace says hello");
            Console.WriteLine("press enter to close");
            Console.ReadLine();
        }
    }
}
