using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch09_LinqToObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[] {"Michael","Pam","Jim","Dwight","Angela","Kevin","Toby","Creed" };
            var query = names
                .ProcessSequence()
                .Where(name => name.Length > 4)
                .OrderBy(name => name.Length)
                .ThenBy(name => name);
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("______________________________________");

            string[] cohort1 = new string[] { "Rachel", "Gareth", "Jonathan", "George" };
            string[] cohort2 = new string[] { "Jack", "Stephen", "Daniel", "Jack", "Jared" };
            string[] cohort3 = new string[] { "Declan", "Jack", "Jack", "Jasmine", "Conor" };
            Output(cohort1, "Cohort 1");
            Output(cohort2, "Cohort 2");
            Output(cohort3, "Cohort 3");
            Console.WriteLine();

            Output(cohort2.Distinct(), "cohort2.Distinct(): removes duplicates");
            Output(cohort2.Union(cohort3), "union combines 2 sequences and removes duplicates");
            Output(cohort2.Concat(cohort3), "concatcombines 2 sequences but does not removes duplicates");
            Output(cohort2.Intersect(cohort3), "intersec returns items that are in both sequences");
            Output(cohort2.Except(cohort3), "except removes items from the first sequence that are in the second sequence");
            Output(cohort1.Zip(cohort2, (c1, c2) => $"{c1} matched with {c2}"), "zip matches items based on position in the sequence");

        }

        static bool NameLongerThanFour(string name)
        {
            return name.Length > 4;
        }

        private static void Output(IEnumerable<string> cohort, string description = "")
        {
            Console.WriteLine(description);
            Console.WriteLine(string.Join(", ", cohort.ToArray()));
        }
    }
}
