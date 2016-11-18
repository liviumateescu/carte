using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch02_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            /*            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), args[0], true);
                        Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), args[1], true);
                        Console.WindowWidth = int.Parse(args[2]);
                        Console.WindowWidth = int.Parse(args[3]);
                        Console.WriteLine("There are {0} arguments",args.Length);
                        foreach (string arg in args)
                        {
                            Console.WriteLine(arg);
                        }
             */
            string[] capete = { "Type", "Byte(s) of Memory", "Min", "Max" };
            Object[] tipuri = {new sbyte(), new byte(), new int(), new uint(), new double()};
            int[] nrBytes = new int[tipuri.Length];
            for (int i = 0; i < tipuri.Length; i++)
            {
                //string ceva = typeof(tipuri[i].GetType());
                Console.WriteLine(tipuri[i].GetType().Name);
               //nrBytes[i] := tipuri[i];
            }
            foreach (Object o in tipuri)
            {
                Type t = o.GetType();
                Console.WriteLine(o.GetType().Name);
                Console.WriteLine(sizeof(o));
            }

            string capTabel="";
            
            foreach (string s in capete)
            {
                capTabel += String.Format("{0, -20}", s);
            }
            Console.WriteLine(capTabel);
            capTabel = "";
            foreach (string s in capete)
            {
                capTabel += String.Format("{0, 20}", s);
            }
            Console.WriteLine(capTabel);



            //StringBuilder typeName = new StringBuilder(typeof(int).Name);
            Console.WriteLine();           

        }
    }
}
