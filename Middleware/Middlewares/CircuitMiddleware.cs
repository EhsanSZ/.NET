using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CircuitMiddleware
    {
        private readonly RequestDelegate _next;

        public CircuitMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            await _next(httpContext);

            if (httpContext.Request.Headers["User-Agent"].Any(p => p.ToLower().Contains("chrome")))
            {
                httpContext.Response.StatusCode = 403;
            }

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CircuitMiddlewareExtensions
    {
        public static IApplicationBuilder UseCircuitMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CircuitMiddleware>();
        }
    }
}
