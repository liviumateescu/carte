using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Web.Script.Serialization;

namespace Ch10_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>
            {
                new Person(30000M) { FirstName = "Alice", LastName = "Smith", DateOfBirth = new DateTime(1974,3,14)},
                new Person(40000M) { FirstName = "Bob", LastName = "Jones", DateOfBirth = new DateTime(1969,11,23)},
                new Person(20000M) { FirstName = "Charlie", LastName = "Rose", DateOfBirth = new DateTime(1964,5,4), Children = new HashSet<Person>
                { new Person(0M) { FirstName = "Saly", LastName = "Rose", DateOfBirth = new DateTime(1990,7,12)} }  }
            };
            string xmlFilePath = @"D:\work\repos\carte\Ch10_People.xml";
            FileStream xmlStream = File.Create(xmlFilePath);

            var xs = new XmlSerializer(typeof(List<Person>));

            xs.Serialize(xmlStream, people);
            xmlStream.Dispose();

            Console.WriteLine($"Written {new FileInfo(xmlFilePath).Length} bytes of xml to {xmlFilePath}");
            Console.WriteLine();
            Console.WriteLine(File.ReadAllText(xmlFilePath));

            FileStream xmlLoad = File.Open(xmlFilePath, FileMode.Open);
            var loadedPeople = (List<Person>)xs.Deserialize(xmlLoad);
            foreach (var item in loadedPeople)
            {
                Console.WriteLine($"{item.LastName} has {item.Children.Count} children.");
            }
                xmlLoad.Dispose();
            Console.WriteLine("------------------------------------------");

            string jsonFilePath = @"D:\work\repos\carte\Ch10_People.json";
            FileStream jsonStream = File.Create(jsonFilePath);

            var jss = new JavaScriptSerializer();
            string json = jss.Serialize(people);
            var writer = new StreamWriter(jsonStream);
            writer.Write(json);

            writer.Dispose();
            Console.WriteLine();
            Console.WriteLine($"Written {new FileInfo(jsonFilePath).Length} bytes of JSON to {jsonFilePath}");

            Console.WriteLine(File.ReadAllText(jsonFilePath));
        }
    }
}
