using DAL;
using Entities3;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RazorPages.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Ui
{
    class Program3
    {
        static void Main(string[] args)
        {
            DataBaseContext3 context = new DataBaseContext3();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            //Add(context);

            //Update(context);

            //Delete(context);

            //Multiple(context);

            //Adding_related(context);

            //Addrelated(context);

            //ChangingRelation(context);

            //Removerrelationships(context);


            //Concurrency(context);


            using (var transaction = context.Database.BeginTransaction())
            {
                Pay pay = new Pay()
                {
                    Date = DateTime.Now,
                };
                context.Pays.Add(pay);
                context.SaveChanges();


                Order order = new Order()
                {

                };
                context.Orders.Add(order);
                context.SaveChanges();


                var orders = context.Orders.ToList();
                var pays = context.Pays.ToList();


                transaction.Rollback();
           

            }



            Console.WriteLine("Hello World!");
        }

        private static void Concurrency(DataBaseContext3 context)
        {
            var category = context.Categories.Find((long)1);
            category.Name = "Laptop";

            bool saved = false;
            while (!saved)
            {
                try
                {
                    context.SaveChanges();
                    saved = true;
                }
                catch (DbUpdateConcurrencyException ex)
                {

                    foreach (var entity in ex.Entries)
                    {
                        if (entity.Entity is Category)
                        {

                            var currentValues = entity.CurrentValues;
                            var databaseValues = entity.GetDatabaseValues();

                            foreach (var property in currentValues.Properties)
                            {
                                var c_value = currentValues[property];
                                var databaseValue = databaseValues[property];

                                if (c_value != databaseValue)
                                {
                                    ///
                                }

                            }
                            entity.OriginalValues.SetValues(databaseValues);
                        }

                    }
                }
            }
        }

        private static void Removerrelationships(DataBaseContext3 context)
        {
            var category = context.Categories.Include(p => p.Products).First(p => p.Id == 2);

            var product = category.Products.First();

            category.Products.Remove(product);
            context.SaveChanges();
        }

        private static void ChangingRelation(DataBaseContext3 context)
        {
            var product = context.Products.Find((long)1);
            Category category = new Category()
            {
                Name = "SE"
            };

            product.Category = category;
            context.SaveChanges();
        }

        private static void Addrelated(DataBaseContext3 context)
        {
            var category = context.Categories.Include(p => p.Products).First(p => p.Id == 2);
            var product = new Product { Name = "Hp" };
            category.Products.Add(product);
            context.SaveChanges();
        }

        private static void Adding_graph(DataBaseContext3 context)
        {
            Category category = new Category()
            {
                Name = "PC",
                Products = new List<Product>()
                 {
                     new Product { Name ="Del"},
                     new Product { Name ="Asus"}
                 },
            };

            context.Categories.Add(category);
            context.SaveChanges();
        }

        private static void Multiple(DataBaseContext3 context)
        {
            //Add
            Category category = new Category()
            {
                Name = "Laptop"
            };
            context.Categories.Add(category);

            //Update
            var categoryUp = context.Categories.First();
            categoryUp.Name = "Mobile";
            //Delete
            context.Categories.Remove(new Category { Id = 1 });

            context.SaveChanges();
        }

        private static void Delete(DataBaseContext3 context)
        {
            var category = context.Categories.Find((long)1);
            //context.Categories.Remove(category);
            context.Categories.Remove(new Category { Id = 1 });
            context.SaveChanges();
        }

        private static void Update(DataBaseContext3 context)
        {
            var category = context.Categories.First();
            category.Name = "Mobile";
            context.SaveChanges();
        }

        private static void Add(DataBaseContext3 context)
        {
            Category category = new Category()
            {
                Name = "Laptop"
            };
            context.Categories.Add(category);
            context.SaveChanges();
        }
    }
}
