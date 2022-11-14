using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Aggregation
{
    public class Aggregation
    {
        public static void Aggregation_Method()
        {

            List<string> data = new List<string>() { "Asp.net Core", "Csharp", "Php", "Java", "nodeJs", "Go" };

            var sep = data.Aggregate((s1, s2) => s1 + "____,=+___" + s2);
            Console.WriteLine(sep);


            Console.WriteLine("______________________________________");



            List<Product> products = new List<Product>()
            {
                new Product { Name = "Asp.Net Core", Price = 10000 },
                 new Product { Name = "C-Shart", Price = 15000 },
                 new Product { Name = "C++", Price = 5000 },
                 new Product { Name = "PHP", Price = 25000 },
                 new Product { Name = "Java", Price = 8000 },
            };

            string sep2 = products.Aggregate<Product, string, string>("Products Name :"
                , (str, p) => str += p.Name + ","
                , str => str.Substring(0, str.Length - 1));

            Console.WriteLine(sep2);
            Console.WriteLine("____________________Average__________________");

            Console.WriteLine(products.Average(p => p.Price).ToString());
            Console.WriteLine("____________________Count__________________");

            Console.WriteLine(products.LongCount().ToString());

            Console.WriteLine("____________________Max__________________");

            Console.WriteLine(products.Max(p => p.Price).ToString());

            Console.WriteLine("____________________Min__________________");

            Console.WriteLine(products.Min(p => p.Price).ToString());

            Console.WriteLine("____________________Sum__________________");

            Console.WriteLine(products.Sum(p => p.Price).ToString());

        }
    }
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
