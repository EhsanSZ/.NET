using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Projection
{
    public class Projection
    {
        public static void Projection_Example()
        {

            List<Category> categories = new List<Category>()
            {
                new Category { Id =1 , Name="mobile" , Products = new List<Product>()
                {
                  new Product { Id =1 , Name ="Iphone Se" , CategoryId = 1 , InsertDate= DateTime.Now.AddYears(-5)},
                  new Product { Id =2 , Name ="Sumsoung G8" , CategoryId = 1, InsertDate= DateTime.Now.AddYears(-8)},
                }},
                new Category { Id =2 , Name="Laptop" , Products = new List<Product> ()
                {

                  new Product { Id =3 , Name ="Asus" , CategoryId = 2, InsertDate= DateTime.Now},
                  new Product { Id =3 , Name ="hp" , CategoryId = 2, InsertDate= DateTime.Now.AddYears(-15)}
                }},
            };

            var data = categories.SelectMany(c => c.Products
             .Where(p => p.InsertDate.Year < 2020)
             .Select(s => new
             {
                 Year = s.InsertDate.Year,
                 Productname = s.Name,
                 Category = c.Name,

             }));

            foreach (var item in data)
            {
                Console.WriteLine($"{item.Productname}   {item.Category}   {item.Year}");
            }

        }
    }

    public class NewListdto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime InsertDate { get; set; }
    }

}

