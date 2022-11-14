using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Quantifiers
{
    public class Quantifiers
    {
        static void Quantifiers_Method()
        {
            List<Product> products = new List<Product>()
            {
                new Product { Name = "Asp.Net Core", Price = 10000 },
                 new Product { Name = "C-Shart", Price = 15000 },
                 new Product { Name = "C++", Price = 5000 },
                 new Product { Name = "PHP", Price = 25000 },
                 new Product { Name = "Java", Price = 8000 },
            };

            Console.WriteLine("__________ALL___________");
            var allResult = products.All(p => p.Price > 9000);
            Console.WriteLine(allResult);


            Console.WriteLine("__________Any___________");
            var anyResult = products.Any(p => p.Price > 9000);

            //var countResult = products.Count(p => p.Price > 9000);
            //if(countResult>= 1)
            //{
            //    ///--------
            //}
            Console.WriteLine(anyResult);


            Console.WriteLine("__________Contains___________");
            var ContainsResult = products.Where(p => p.Name.Contains("C"));
            foreach (var item in ContainsResult)
            {
                Console.WriteLine($"{item.Name}");
            }

        }
    }
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
