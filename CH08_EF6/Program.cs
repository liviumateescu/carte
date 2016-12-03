using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CH08_EF6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List of products that cost more than a given price with most expensive first.");
            string input;
            decimal price;
            do
            {
                Console.Write("Enter a product price: ");
                input = Console.ReadLine();
            } while (!decimal.TryParse(input, out price));

            TransactionOptions options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted,
                Timeout = TimeSpan.FromSeconds(10)
            };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
            {

                Northwind db = new Northwind();
                db.Database.Connection.Open();
                //db.Database.Log = new Action<string>(message => { Console.WriteLine(message); });

                IQueryable<Product> query = db.Products.Where(product => product.UnitPrice > price).OrderByDescending(product => product.UnitPrice);

                //Console.WriteLine(query.ToString());

                foreach (Product item in query)
                {
                    Console.WriteLine($"{item.ProductID} : {item.ProductName} costs {item.UnitPrice:$#,##0.00}");
                }
                Console.WriteLine("--------------------------------------------------------------");

                Product newProduct = new Product
                {
                    ProductName = "Bob's burger",
                    UnitPrice = 500M
                };
                db.Products.Add(newProduct);
                db.SaveChanges();
                foreach (Product item in query)
                {
                    Console.WriteLine($"{item.ProductID} : {item.ProductName} costs {item.UnitPrice:$#,##0.00}");
                }
                Console.WriteLine("--------------------------------------------------------------");


                Product updateProduct = db.Products.Find(78);
                updateProduct.UnitPrice += 20M;
                db.SaveChanges();
                foreach (Product item in query)
                {
                    Console.WriteLine($"{item.ProductID} : {item.ProductName} costs {item.UnitPrice:$#,##0.00}");
                }

                db.Database.Connection.Close();
            }
        }
    }
}
