using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ch10_FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string dir = @"D:\work\repos\carte\Ch10_Example";
            Console.WriteLine($"Does {dir} exist? {Directory.Exists(dir)}");
            Directory.CreateDirectory(dir);
            Console.WriteLine($"Does {dir} exist? { Directory.Exists(dir)}");
            Directory.Delete(dir);
            Console.WriteLine($"Does {dir} exist? { Directory.Exists(dir)}");

            string textFile = @"D:\work\repos\carte\Ch10.txt";
            string backupFile = @"D:\work\repos\carte\Ch10.bak";
            Console.WriteLine($"Does {textFile} exist? {File.Exists(textFile)}");
            StreamWriter textWriter = File.CreateText(textFile);
            textWriter.WriteLine("un test");
            textWriter.Dispose();
            Console.WriteLine($"Does {textFile} exist? {File.Exists(textFile)}");

            File.Copy(textFile, backupFile, true);
            Console.WriteLine($"Does {backupFile} exist? {File.Exists(backupFile)}");

            File.Delete(textFile);
            Console.WriteLine($"Does {textFile} exist? {File.Exists(textFile)}");

            var textReader = File.OpenText(backupFile);
            Console.WriteLine(textReader.ReadToEnd());
            textReader.Dispose();

            Console.WriteLine($"File Name: {Path.GetFileName(textFile)}");
            Console.WriteLine($"file Name without extension: {Path.GetFileNameWithoutExtension(textFile)}");
            Console.WriteLine($"File extension: {Path.GetExtension(textFile)}");
            Console.WriteLine($"random file name: {Path.GetRandomFileName()}");
            Console.WriteLine($"temporary file name: {Path.GetTempFileName()}");

            string backup = @"D:\work\repos\carte\Ch10.bak";
            FileInfo info = new FileInfo(backup);
            Console.WriteLine($"{backup} contains {info.Length} bytes.");
            Console.WriteLine($"{backup} was last accesed {info.LastAccessTime}.");
            Console.WriteLine($"{backup} was readonly set to {info.IsReadOnly}.");
            
        }
    }
}
