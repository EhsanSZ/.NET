using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Security.Controllers
{
    [EnableCors("MyCors")]
    public class Cors : Controller
    {
        [DisableCors]
        public IActionResult Index()
        {
            return View();
        }
    
        [HttpPut]
        public string GetData()
        {
            return "Data From Api";
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
