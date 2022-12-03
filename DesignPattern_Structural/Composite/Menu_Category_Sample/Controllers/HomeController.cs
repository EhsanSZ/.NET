using Menu_Category_Sample.Models;
using Menu_Category_Sample.Models.Contexts;
using Menu_Category_Sample.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Menu_Category_Sample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataBaseContext context;
        public HomeController(ILogger<HomeController> logger
            , DataBaseContext context)
        {
            this.context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var menus = context.CategoryComponents.ToList();
            string result = "";
            foreach (var item in menus.Where(p => p.GetType() == typeof(CategoryItem)))
            {
                context.Products.Add(new Product
                {
                    Name = "test",
                    CategoryItem = item as CategoryItem,
                });
                context.SaveChanges();

                result += item.Print();
            }
            return View("Index", result);

        }

        public IActionResult TempData()
        {
            var Products = new Category("محصولات");
            var testItem = new CategoryItem("موبایل", "https://Ehsansz.ir/");
            Products.Add(testItem);
            Products.Add(new CategoryItem("لپ تاپ", "https://Ehsansz.ir/"));
            Products.Add(new CategoryItem("لوازم جانبی", "https://Ehsansz.ir/"));
            Products.Add(new CategoryItem("کتاب", "https://Ehsansz.ir/"));

            context.CategoryComponents.Add(Products);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
