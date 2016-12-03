using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ch09_LINQandXML
{
    class Program
    {
        static void Main(string[] args)
        {
            Northwind db = new Northwind();
            var products = db.Products.ToArray();

            var xml = new XElement("products",
                            from p in products
                            select new XElement("product",
                                new XAttribute("id", p.ProductID),
                                new XAttribute("price", p.UnitPrice),
                                new XElement("name", p.ProductName)));
            Console.WriteLine(xml.ToString());

            XDocument doc = XDocument.Load("Ch09_LINQandXML.exe.config");
            var appSettings = doc.Descendants("appSettings").Descendants("add")
                                .Select(node => new
                                {
                                    Key = node.Attribute("key").Value,
                                    Value = node.Attribute("value").Value
                                })
                                .ToArray();

            foreach (var item in appSettings)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
        }
    }
}