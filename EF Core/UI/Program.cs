using DAL;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using static DAL.DataBaseContext;

namespace Ui
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBaseContext context = new DataBaseContext();

            //EagerLoading(context);
            //ExplicitLoading(context);

            var posts = context.Posts.FirstOrDefault();

            foreach (var item in posts.Comments)
            {
                Console.WriteLine(item.User.Name);
            }
            Console.ReadLine();
        }

        private static void ExplicitLoading(DataBaseContext context)
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

        private static void EagerLoading(DataBaseContext context)
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
