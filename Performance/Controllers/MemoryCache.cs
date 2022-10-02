using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace Performance.Controllers
{
    public class MemoryCache : Controller
    {

        private readonly IMemoryCache _cache;
        private readonly string key = "_MyData";
        public MemoryCache(IMemoryCache cache)
        {
            _cache = cache;
        }

        public IActionResult Index()
        {
            DateTime myValue;
            if (!_cache.TryGetValue(key, out myValue))
            {
                myValue = DateTime.Now;
                var cacheOption = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(20))
                    .RegisterPostEvictionCallback(RemoveCallback, this);
                _cache.Set(key, myValue, cacheOption);
            }
            return View(myValue);
        }


        private static void RemoveCallback(object key, object value,
            EvictionReason reason, object state)
        {
            
        }


        public IActionResult RemoveCache()
        {
            _cache.Remove(key);
            return View(nameof(Index));
        }

        public IActionResult GetCache()
        {
            var myValue = _cache.Get(key);
            return View(nameof(Index), myValue);
        }
        public IActionResult GetOrCreateCache()
        {
            var myValue = _cache.GetOrCreate(key, p =>
            {
                p.SetSlidingExpiration(TimeSpan.FromSeconds(20));

                return DateTime.Now;
            });
            return View(nameof(Index), myValue);
        }

        public async Task<IActionResult> GetOrCreateCacheAsynchronous()
        {
            var myValue = await _cache.GetOrCreateAsync(key, p =>
            {
                p.SlidingExpiration = TimeSpan.FromSeconds(5);
                return Task.FromResult(DateTime.Now);
            });
            return View(nameof(Index), myValue);

        }


        public IActionResult Privacy()
        {
            return View();
        }

    }
}
