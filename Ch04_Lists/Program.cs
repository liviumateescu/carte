using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch04_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cities = new List<string>();
            cities.Add("London");
            cities.Add("Paris");
            cities.Add("Milan");
            Console.WriteLine("initial list");
            foreach (string city in cities)
            {
                Console.WriteLine($"  {city}");
            }
            Console.WriteLine($"primul oras: {cities[0]}.");
            Console.WriteLine($"ultimul oras: {cities[cities.Count -1 ]}.");
            cities.Insert(0,"Sydney");
            Console.WriteLine("dupa ce am inserat sidney la pozitia 0");
            foreach (string city in cities)
            {
                Console.WriteLine($"  {city}");
            }
            cities.RemoveAt(1);
            cities.Remove("Milan");
            Console.WriteLine("dupa ce am sters doua orase");
            foreach (string city in cities)
            {
                Console.WriteLine($"  {city}");
            }
        }
    }
}
