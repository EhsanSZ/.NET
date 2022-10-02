using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApplication1.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ResposeMiddleware
    {
        private readonly RequestDelegate _next;

        public ResposeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            await _next(httpContext);
            if (httpContext.Response.StatusCode == 404)
            {
                await httpContext.Response.WriteAsync("Not ...");
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ResposeMiddlewareExtensions
    {
        public static IApplicationBuilder UseResposeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResposeMiddleware>();
        }
    }
}
