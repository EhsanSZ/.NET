using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Filters.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using Filters.Models.Filters;

namespace Filters.Controllers
{
 
   //[ShowMessage("Controller")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [TypeFilter(typeof(CustomExceptionFilter))]
        public IActionResult Error()
        {
            throw new NotImplementedException(); 
        }


        [ValidateModelAttribute]
        [HttpPost]
        public IActionResult ProductEdit([FromForm] ProductViewmodel product)
        {
       
            return View();
        }


         //[CacheResourceFilter]
         //[TypeFilter(typeof(CacheResourceFilter))]
          //[AddHeaderFilter] 
         //[ShowMessage("Action")]
         //[TypeFilter(typeof(ShowMessage))]
         [ServiceFilter(typeof(AddHeaderFilter))]
        public IActionResult Index()
        {
            return View("Index",$"This is a text and gnerated at:{DateTime.Now.TimeOfDay}");
        }      
        
        
        [AuthorizeActionFilter("User")]
        public IActionResult List()
        {
            return View();
        }

        [AuthorizeActionFilter("Admin")]
        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
