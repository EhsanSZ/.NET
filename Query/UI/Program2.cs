using DAL;
using Entities2;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using static DAL.DataBaseContext2;

namespace Ui
{
    class Program2
    {
        static void Main(string[] args)
        {
            DataBaseContext2 context = new DataBaseContext2();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();
            // ClientCsServer(context);
            //TrackingVsNoTracking(context);
            //FromSqlRaw(context);


            //var users = context.Users.ToList();
            //var usersALL = context.Users.IgnoreQueryFilters().ToList();


            //var usersEnummerable = context.Users.AsEnumerable();

            //usersEnummerable = usersEnummerable.Where(p => p.Name.Contains("m"));

            //var userList1 = usersEnummerable.ToList();


            //var userQueryable = context.Users.AsQueryable();
            //userQueryable = userQueryable.Where(p => p.Name.Contains("M"));
            //var userlist2 = userQueryable.ToList();


            context.Users.Any(p => p.Name.Contains("m"));



            Console.ReadLine();
        }

        private static void FromSqlRaw(DataBaseContext2 context)
        {
            var post = context.Posts.FromSqlRaw("SELECT * FROM dbo.Posts").ToList();
        }

        private static void TrackingVsNoTracking(DataBaseContext2 context)
        {
            //context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            // ClientCsServer(context);

            var tags = context.Tags.ToList();


            var post = context.Posts.FirstOrDefault();

            post.Body = "E";
            context.SaveChanges();

            var tag1 = context.Tags.Where(p => p.Id == 1).FirstOrDefault();

            var tag2 = context.Tags.Find((long)2);
        }

        private static void ClientCsServer(DataBaseContext2 context)
        {
            //var products = context.Products.AsEnumerable().Where(p=> CalculateTax(p.Price) >1000 )
            //    .Select(p => new
            //{
            //    Price = CalculateTax(p.Price),
            //}).ToList();


            var products = context.Products.Where(p => p.Price > 9000)
            .Select(p => new
            {
                Price = CalculateTax(p.Price),
            }).ToList();




            foreach (var item in products)
            {
                Console.WriteLine(item.Price);
            }
        }

        public static decimal CalculateTax(decimal price)
        {
            return (price * 9) / 100;
        }

    }
}
