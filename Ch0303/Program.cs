using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ch0303
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream file = null;
            StreamWriter writer = null;
            try
            {
                file = File.OpenWrite(@"c:\code\file.txt");
                writer = new StreamWriter(file);
                writer.WriteLine("Hello C#");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType()} says {ex.Message}");
            }
            finally
            {
                if (writer != null)
                {
                    writer.Dispose();
                    Console.WriteLine("The writer's unmanaged resources have been disposed.");
                }
                if (file != null)
                {
                    file.Dispose();
                    Console.WriteLine("The file's unmanaged resources have been disposed.");
                }
            }
            int a;
            using (FileStream file2 = File.OpenWrite(@"c:\code\file2.txt"))
            {
                using (StreamWriter writer2 = new StreamWriter(file2))
                {
                    writer2.WriteLine("iar hello");
                }
            }

            using (FileStream file2 = File.OpenWrite(@"c:\code\file3.txt"))
            {
                using (StreamWriter writer2 = new StreamWriter(file2))
                {
                    try {
                    writer2.WriteLine("iar hello");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.GetType()} says {ex.Message}");
                    }
                }
            }
        }
    }
}
