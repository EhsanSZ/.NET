using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Redis.Models;
using Redis.Models.Dto;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.Json;


namespace RedisCacheInAspNetCore.Bugeto.Controllers
{
    public class RedisController : Controller
    {
        private readonly ILogger<RedisController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IDistributedCache _cache;
        public RedisController(ILogger<RedisController> logger,
            IProductRepository productRepository,
            IDistributedCache distributedCache)
        {
            _logger = logger;
            _productRepository = productRepository;
            _cache = distributedCache;
        }

        public IActionResult Index()
        {
            HomePageDto homePageData = new HomePageDto();

            var homePageCache = _cache.GetAsync("HomePageData").Result;
            if (homePageCache != null)
            {
                homePageData = JsonSerializer.Deserialize<HomePageDto>(homePageCache);
                ViewBag.From = "  از کش دریافت شد";
            }
            else
            {
                homePageData = _productRepository.GetHomePageProducts();

                string jsonData = JsonSerializer.Serialize(homePageData);

                byte[] encodedJson = Encoding.UTF8.GetBytes(jsonData);

                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(10))
                    ;
                _cache.SetAsync("HomePageData", encodedJson, options);
                ViewBag.From = "از دیتابیس دریافت شد";

            }
            return View(homePageData);
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
