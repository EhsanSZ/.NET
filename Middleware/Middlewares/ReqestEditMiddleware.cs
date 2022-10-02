using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ReqestEditMiddleware
    {
        private readonly RequestDelegate _next;

        public ReqestEditMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string temp = httpContext.Request.Headers["User-Agent"];
            httpContext.Items["IsChromeBrowser"] = httpContext.Request.Headers["User-Agent"].Any(p => p.ToLower().Contains("chrome"));

            
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ReqestEditMiddlewareExtensions
    {
        public static IApplicationBuilder UseReqestEditMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ReqestEditMiddleware>();
        }
    }
}
