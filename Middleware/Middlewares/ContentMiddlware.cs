using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApplication1.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ContentMiddlware
    {
        private readonly RequestDelegate _next;

        public ContentMiddlware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().ToLower().Contains("/content"))
            {
                await httpContext.Response.WriteAsync("Hi Ehsan");
            }
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ContentMiddlwareExtensions
    {
        public static IApplicationBuilder UseContentMiddlware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ContentMiddlware>();
        }
    }
}
