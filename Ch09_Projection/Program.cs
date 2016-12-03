using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch09_Projection
{
    class Program
    {
        static void Main(string[] args)
        {
            /*            Northwind db = new Northwind();
                        var query = db.Products
                            .Where(product => product.UnitPrice < 10M)
                            .OrderByDescending(product => product.UnitPrice)
                            .Select(product => new { product.ProductID, product.ProductName, product.UnitPrice});
                        Console.WriteLine(query.ToString());
                        foreach (var item in query)
                        {
                            Console.WriteLine($"{item.ProductID} : {item.ProductName} costs {item.UnitPrice:$#.##0.00}");
                        }
            */
            Northwind db = new Northwind();
            var categories = db.Categories.Select(c => new { c.CategoryID, c.CategoryName }).ToArray();
            var products = db.Products.Select(p => new { p.ProductID, p.ProductName, p.CategoryID}).ToArray();
            var queryJoin = categories.Join(products,
                category => category.CategoryID,
                product => product.CategoryID,
                (c, p) => new { c.CategoryName, p.ProductName, p.ProductID })
                .OrderBy(cp => cp.ProductID);
            foreach (var item in queryJoin)
            {
                Console.WriteLine($"{item.ProductID} : {item.ProductName} is in {item.CategoryName}");
            }
            Console.WriteLine("----------------------------------------------------");

            var queryGroup = categories.GroupJoin(products,
                category => category.CategoryID,
                product => product.CategoryID,
                (c, Products) => new { c.CategoryName, Products = Products.OrderBy(p => p.ProductName) });
            foreach (var item in queryGroup)
            {
                Console.WriteLine($"{item.CategoryName} has {item.Products.Count()} products.");
                foreach (var product in item.Products)
                {
                    Console.WriteLine($"   {product.ProductName}");
                }
            }
        }
    }
}
