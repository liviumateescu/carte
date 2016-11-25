using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Ch05_Monitoring
{
    class Recorder
    {
        static Stopwatch timer = new Stopwatch();
        static long bytesPhysicalBefore = 0;
        static long bytesVirtualBefore = 0;
        public static void Start()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            bytesPhysicalBefore = Process.GetCurrentProcess().WorkingSet64;
            bytesVirtualBefore = Process.GetCurrentProcess().VirtualMemorySize64;
            timer.Restart();
        }
        public static void Stop()
        {
            timer.Stop();
            long bytesPhysicalAfter = Process.GetCurrentProcess().WorkingSet64;
            long bytesVirtualAfter = Process.GetCurrentProcess().VirtualMemorySize64;
            Console.WriteLine("Stopped recording");
            Console.WriteLine($"{bytesPhysicalAfter - bytesPhysicalBefore:N0} physical bytes used.");
            Console.WriteLine($"{bytesVirtualAfter - bytesVirtualBefore:N0} virtual bytes used.");
            Console.WriteLine($"{timer.Elapsed} time span ellapsed");
            Console.WriteLine($"{timer.ElapsedMilliseconds:N0} total milliseconds ellapsed");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press enter to start the timer:");
            Console.ReadLine();
            Recorder.Start();
            int[] largeArray = Enumerable.Range(1, 10000).ToArray();
            Console.WriteLine("Press enter to stop the timer:");
            Console.ReadLine();
            Recorder.Stop();
            Console.ReadLine();

            int[] numbers = Enumerable.Range(1, 10000).ToArray();
            Recorder.Start();
            Console.WriteLine("using string");
            string s = "";
            for (int i = 0; i < numbers.Length; i++)
            {
                s += numbers[i] + ", ";
            }
            Recorder.Stop();
            Recorder.Start();
            Console.WriteLine("using StringBuilder");
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < numbers.Length; i++)
            {
                builder.Append(numbers[i]);
                builder.Append(", ");
            }
            Recorder.Stop();
            Console.ReadLine();
        }
    }
}
