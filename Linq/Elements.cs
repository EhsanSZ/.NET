using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Elements
{
    public class Elements
    {
        static void Elements_Method(string[] args)
        {
            List<Product> products = new List<Product>()
            {
                new Product { Name = "Asp.Net Core", Price = 10000 },
                 new Product { Name = "C-Sharp", Price = 15000 },
                 new Product { Name = "C++", Price = 5000 },
                 new Product { Name = "PHP", Price = 25000 },
                 new Product { Name = "Java", Price = 8000 },
                 new Product { Name = "Java-h", Price = 9000 },
            };

            List<Product> productsEmp = new List<Product>();

            var product = products.ElementAt(0);
            var product2 = productsEmp.ElementAtOrDefault(0);

            var productFirst = products.First(p => p.Name.Contains("h"));
            var productFirstempty = productsEmp.FirstOrDefault();

            var productLast = products.Last(p => p.Name.Contains("h"));
            var productLastempty = productsEmp.LastOrDefault();


            List<Product> productsSinle = new List<Product>();
            //{
            //    new Product { Name = "Asp.Net Core Single", Price = 10000 },

            //};


            var single = productsSinle.SingleOrDefault();

            Console.ReadLine();
        }
    }
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
