using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace Ch02_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            /*            System.Data.SqlClient.SqlConnection connection;
                        System.Xml.XmlReader reader;
                        System.Xml.Linq.XElement element;
                        System.Net.Http.HttpClient client;

                        foreach (var r in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
                        {
                            var a = Assembly.Load(r.FullName);
                            int methodCount = 0;
                            foreach (var t in a.DefinedTypes)
                            {
                                methodCount += t.GetMethods().Count();
                            }
                            Console.WriteLine($"{a.DefinedTypes.Count()} types with {methodCount} methods in {r.Name} assembly.");
                        }
            */

            double inaltime = 1.88;
            Console.WriteLine($"variabila {nameof(inaltime)} are valoarea {inaltime}.");

        }
    }
}
