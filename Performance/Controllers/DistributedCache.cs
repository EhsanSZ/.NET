using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Diagnostics;
using System.Text;

namespace Performance.Controllers
{
    public class DistributedCache : Controller
    {
        private readonly IDistributedCache _cache;
        public DistributedCache(IDistributedCache cache)
        {
            _cache = cache;
        }

        public IActionResult Index()
        {
            string myValue = ""; 
            var myValueEncoded = _cache.Get("myCacheKey");
            if (myValueEncoded != null)
            {
                myValue = Encoding.UTF8.GetString(myValueEncoded);

            }
            else
            {
                myValue = DateTime.Now.ToString();
                byte[] currentValueEncoded = Encoding.UTF8.GetBytes(myValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(30));
                _cache.Set("myCacheKey", currentValueEncoded, options);
            }
            return View("Index", myValue);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }

        //    dotnet tool install --global dotnet-sql-cache
        //url https://www.nuget.org/packages/dotnet-sql-cache

        //dotnet sql-cache create "Data Source=.;Initial Catalog=DbCache;Integrated Security=True;" dbo tblCache
}

