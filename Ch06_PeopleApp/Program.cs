using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Packt.CS6;

namespace Ch06_PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Name = "Bob Smith";
            p1.DateOfBirth = new DateTime(1965, 12, 22);
            p1.FavouriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
            p1.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
            p1.Children.Add(new Person());
            p1.Children.Add(new Person());
            Console.WriteLine($"{p1.Name} was born on {p1.DateOfBirth:dddd, d MMMM yyyy}");
            Console.WriteLine($"{p1.Name}'s favourite wonder is {p1.FavouriteAncientWonder}");
            Console.WriteLine($"{p1.Name}'s bucjket list is {p1.BucketList}");
            Console.WriteLine($"{p1.Name} has {p1.Children.Count} children.");
            Console.WriteLine($"{p1.Name} is a {Person.Species}");
            Console.WriteLine($"{p1.Name} is from {p1.HomePlanet}");
            Console.WriteLine("*************************************************************************");
            p1.WriteToConsole();
            Console.WriteLine(p1.GetOrigin());
            Console.WriteLine("*************************************************************************");
            Console.WriteLine(p1.SayHello());
            Console.WriteLine(p1.SayHello("Emily"));

            Person p2 = new Person { Name = "Alice", DateOfBirth=new DateTime(1998,3,17) };
            p2.FavouriteAncientWonder = WondersOfTheAncientWorld.GreatPyramidOfGiza;
            p2.BucketList = WondersOfTheAncientWorld.TempleOfArtemisAtEphesus | WondersOfTheAncientWorld.LighthouseOfAlexandria;
            Console.WriteLine($"{p2.Name} was born on {p2.DateOfBirth:dddd, d MMMM yyyy}");
            Console.WriteLine($"{p2.Name}'s favourite wonder is {p2.FavouriteAncientWonder}");
            Console.WriteLine($"numele primului copil este : { p1.Children.First().Name}");
            Console.WriteLine("\n*************************************************************************\n");

            Person p3 = new Person();
            Console.WriteLine($"{p3.Name} was instantiated at {p3.Instantiated:hh:mm:ss} on {p3.Instantiated:dddd, d MMMM yyyy}");

            Person p4 = new Person("Aziz");
            Console.WriteLine($"{p4.Name} was instantiated at {p4.Instantiated:hh:mm:ss} on {p4.Instantiated:dddd, d MMMM yyyy}");

            BankAccount.InterestRate = 0.012M;
            BankAccount ba1 = new BankAccount();
            ba1.AccountName = "Mrs. jones";
            ba1.Balance = 2400;
            Console.WriteLine($"{ba1.AccountName} earned {ba1.Balance * BankAccount.InterestRate} intrest.");
            BankAccount ba2 = new BankAccount();
            ba2.AccountName = "Ms. Gerrier";
            ba2.Balance = 98;
            Console.WriteLine($"{ba2.AccountName} earned {ba2.Balance * BankAccount.InterestRate} intrest.");

            Person max = new Person { Name = "Max", DateOfBirth=new DateTime(1972,1,27)};
            Console.WriteLine("*************************************************************************");
            Console.WriteLine(max.Origin);
            Console.WriteLine(max.Greeting);
            Console.WriteLine(max.age);
            max.FavouriteIceCream = "Chocolate Fudge";
            Console.WriteLine($"Max's favourite icecream flavour is {max.FavouriteIceCream}.");
            max.FavouritePrimaryColor = "Red";
            Console.WriteLine($"Max's favourite primary color is {max.FavouritePrimaryColor}.");

            max.Children.Add(new Person { Name = "Charlie"});
            max.Children.Add(new Person { Name = "Ella" });
            Console.WriteLine($"Max's first child is {max.Children[0].Name}");
            Console.WriteLine($"Max's second child is {max.Children[1].Name}");
            Console.WriteLine($"Max's first child is {max[0].Name}");
            Console.WriteLine($"Max's first child is {max[1].Name}");

            Console.WriteLine("*************************************************************************");
            Person harry = new Person { Name = "Hary" };
            Person marry = new Person { Name = "Mary" };
            Person baby1 = harry.Procreate(marry);
            Console.WriteLine($"{marry.Name} has {marry.Children.Count} children.");
            Console.WriteLine($"{harry.Name} has {harry.Children.Count} children.");
            Person baby2 = harry * marry;
            Console.WriteLine($"{marry.Name} has {marry.Children.Count} children.");

            p1.Shout += P1_Shout;
            p1.Poke();
            p1.Poke();
            p1.Poke();
            p1.Poke();

            Person[] people =
            {
                new Person { Name = "Simon" },
                new Person { Name = "Jenny" },
                new Person { Name = "Adam" },
                new Person { Name = "Richard" },
            };
            Array.Sort(people);
            foreach (Person person in people)
            {
                Console.WriteLine($"{person.Name}");
            }

            Array.Sort(people, new PersonComparer());
            foreach (Person p in people)
            {
                Console.WriteLine($"{p.Name}");
            }

            DisplacementVector dv1 = new DisplacementVector(3, 5);
            DisplacementVector dv2 = new DisplacementVector(-2, 7);
            DisplacementVector dv3 = dv1 + dv2;
            Console.WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) = ({dv3.X}, {dv3.Y})");

        }


        private static void P1_Shout(object sender, EventArgs e)
        {
            Person p = (Person)sender;
            Console.WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
        }
    }
}
