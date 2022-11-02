using DAL;
using Entities1;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using static DAL.DataBaseContext1;

namespace Ui
{
    class Program1
    {
        static void Main(string[] args)
        {
            DataBaseContext1 context = new DataBaseContext1();

            //EagerLoading(context);
            //ExplicitLoading(context);

            var posts = context.Posts.FirstOrDefault();

            foreach (var item in posts.Comments)
            {
                Console.WriteLine(item.User.Name);
            }
            Console.ReadLine();
        }

        private static void ExplicitLoading(DataBaseContext1 context)
        {
            var post = context.Posts.Where(p => p.Id == 1).FirstOrDefault();

            context.Entry(post)
                .Collection(p => p.Comments)
                .Load();


            context.Entry(post)
                .Reference(p => p.Category)
                .Load();

            var commntCount = context.Entry(post)
                .Collection(p => p.Comments)
                .Query()
                .Where(p => p.IsConfirm == true)
                .Count();
        }

        private static void EagerLoading(DataBaseContext1 context)
        {
            //var postQuery = context.Posts.TagWith("Get All Post").ToQueryString();
            //var post = context.Posts.TagWith("This is a comment").ToList();
            //Console.WriteLine(postQuery);

            //var posts = context.Posts
            //    .Include(p=> p.Comments).ThenInclude(p => p.User)
            //    .Include(p=> p.Category)
            //    .Include(p=> p.Tags).FirstOrDefault();

            //foreach (var item in posts.Comments)
            //{
            //    Console.WriteLine(item.User.Name);

            //}

            //var post = context.Posts.Include(p => p.Comments).ToList();
            //var postSplit = context.Posts.Include(p => p.Comments).AsSplitQuery().TagWith("AsSplitQuery").ToList();

            var posts = context.Posts.Include(p => p.Comments.Where(c => c.IsConfirm == true)).ToList();
        }
    }
}
