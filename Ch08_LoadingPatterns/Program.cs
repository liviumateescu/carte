using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch08_LoadingPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading patterns with the Entity Framework");
            Northwind db = new Northwind();
            IQueryable<Category> query;

            Console.WriteLine("Enable lazy loading? (Y/N): ");
            var lazyloading = (Console.ReadKey().Key == ConsoleKey.Y);
            db.Configuration.LazyLoadingEnabled = lazyloading;
            Console.WriteLine();

            Console.WriteLine("Enable logging? (Y/N): ");
            var logging = (Console.ReadKey().Key == ConsoleKey.Y);
            if (logging)
            {
                db.Database.Log = new Action<string>(message => { Console.WriteLine(message); });
            }
            Console.WriteLine();

            Console.WriteLine("Enable eager loading? (Y/N): ");
            var eagerloading = (Console.ReadKey().Key == ConsoleKey.Y);
            if (eagerloading)
            {
                query = db.Categories.Include("Products");
            }
            else
            {
                query = db.Categories;
            }
            Console.WriteLine();

            Console.WriteLine("Explicit loading? (Y/N): ");
            var explicitloading = (Console.ReadKey().Key == ConsoleKey.Y);
            Console.WriteLine();

            foreach (var item in query)
            {
                if (explicitloading)
                {
                    Console.WriteLine($"Explicitly load products for {item.CategoryName}? (Y/N): ");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        var products = db.Entry(item).Collection(c => c.Products);
                        if (!products.IsLoaded) products.Load();
                    }
                    Console.WriteLine();
                }
                Console.WriteLine($"{item.CategoryName} has {item.Products.Count} products.");
            }
            
        }
    }
}
