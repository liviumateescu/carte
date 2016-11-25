using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.CS6
{
    public partial class Person
    {
        public string Name;
        public DateTime DateOfBirth;
        public WondersOfTheAncientWorld FavouriteAncientWonder;
        public WondersOfTheAncientWorld BucketList;
        public const string Species = "Homo Sapiens";
        public readonly string HomePlanet = "Earth";
        public readonly DateTime Instantiated;

        public List<Person> Children = new List<Person>();

        public Person()
        {
            Name = "Unknown";
            Instantiated = DateTime.Now;
        }

        public Person(string initialName)
        {
            Name = initialName;
            Instantiated = DateTime.Now;
        }

        public void WriteToConsole()
        {
            Console.WriteLine($"{Name} was born on {DateOfBirth:dddd, d MMMM yyyy}"); ;
        }

        public string GetOrigin()
        {
            return $"{Name} was born on {HomePlanet}";
        }

        public string SayHello()
        {
            return $"{Name} says Hello!";
        }

        public string SayHello(string name)
        {
            return $"{Name} says Hello {name}!";
        }
    }
}
