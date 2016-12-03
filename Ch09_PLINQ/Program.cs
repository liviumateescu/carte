using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Ch09_PLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = Stopwatch.StartNew();
            Console.WriteLine("Press Enter to start");
            Console.ReadLine();
            watch.Start();
            IEnumerable<int> numbers = Enumerable.Range(1, 200000000);
            var squares = numbers.AsParallel().Select(number => number * 2).ToArray();
            watch.Stop();
            Console.WriteLine($"{watch.ElapsedMilliseconds:#,##0} elapsed miliseconds.");

        }
    }
}
