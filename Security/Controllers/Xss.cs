using Ganss.XSS;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Security.Controllers
{
    public class Xss : Controller
    {
        public IActionResult Index()
        {
            var sanitizer = new HtmlSanitizer();

            string Body = "Database script";

            return View(sanitizer.Sanitize(Body));
        }

        [HttpPost]
        public IActionResult SendComment(string body)
        {
            var sanitizer = new HtmlSanitizer();
            var result = sanitizer.Sanitize(body);

            //_context.Comments.Add(body);
            //_context.SaveChanges();
            return RedirectToAction("Index");
        }
    }


        public class CSPMiddleware
        {
            private readonly RequestDelegate _next;

            public CSPMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            public Task Invoke(HttpContext httpContext)
            {
                httpContext.Response.Headers.Add("Content-Security-Policy", "script-src 'self'");
                return _next(httpContext);
            }
        }

        public static class CSPMiddlewareExtenstion
        {
            public static IApplicationBuilder UseCSP(this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<CSPMiddleware>();
            }
        }

}

