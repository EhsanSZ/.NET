using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Security.Controllers
{
    public class IP : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

    public class SafeIpMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _IpAddressSafe;
        public SafeIpMiddleware(RequestDelegate next, string IpAddressSafe)
        {
            _next = next;
            _IpAddressSafe = IpAddressSafe;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //if(httpContext.Request.Method == HttpMethods.Post)
            //{
            //}

            var userIp = httpContext.Connection.RemoteIpAddress;
            string[] safeIp = _IpAddressSafe.Split(';');
            var userIpbytes = userIp.GetAddressBytes();

            bool IsBlock = true;
            foreach (var item in safeIp)
            {
                var temIp = IPAddress.Parse(item);
                if (temIp.GetAddressBytes().SequenceEqual(userIpbytes))
                {
                    IsBlock = false;
                    break;
                }
            }

            if (IsBlock == true)
            {
                httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                return;
            }

            await _next(httpContext);
        }
    }
}
