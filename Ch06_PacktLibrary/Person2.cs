using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.CS6
{
    public partial class Person : IComparable<Person>
    {
        public string Origin {
            get
            {
                return $"{Name} was born on {HomePlanet}";
            }
        } 

        public string Greeting => $"{Name} says Hello!";
        public int age => (int)(DateTime.Today.Subtract(DateOfBirth).TotalDays / 365.25);

        public string FavouriteIceCream { get; set; }
        private string favouritePrimaryColor;
        public string FavouritePrimaryColor {
            get
            {
                return favouritePrimaryColor;
            }
            set
            {
                switch (value.ToLower())
                {
                    case "red":
                    case "green":
                    case "blue":
                        favouritePrimaryColor = value;
                        break;
                    default:
                        throw new ArgumentException($"{value} is not a primary color. Choose from: red, green, blue.");
                }
            }
        }

        public Person this[int index]
        {
            get
            {
                return Children[index];
            }
            set
            {
                Children[index] = value;
            }
        }

        public Person Procreate(Person partner)
        {
            Person baby = new Person("Baby");
            this.Children.Add(baby);
            partner.Children.Add(baby);
            return baby;

        }

        public static Person operator * (Person p1, Person p2)
        {
            return p1.Procreate(p2);
        }

        public event EventHandler Shout;
        public int AngerLevel;
        public void Poke()
        {
            AngerLevel++;
            if (AngerLevel >= 3)
            {
                if (Shout != null)
                {
                    Shout(this, EventArgs.Empty);
                }
            }
        }

        public int CompareTo(Person other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
