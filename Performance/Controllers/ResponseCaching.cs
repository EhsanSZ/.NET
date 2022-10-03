using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Performance.Controllers
{
    [ResponseCache(CacheProfileName = "default")]
    public class ResponseCaching : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

    public class EditHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public EditHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            int age = 10;
            httpContext.Request.Headers.Add("Cache-Control", $"public,max-age={age}");
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class EditHeaderMiddlewareExtensions
    {
        public static IApplicationBuilder UseEditHeaderMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<EditHeaderMiddleware>();
        }
    }
}
