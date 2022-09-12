using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.CompilerServices;
using ModelBinding.Models;

namespace Routing.Controllers
{
    public class Home2Controller : Controller
    {
        private readonly ILogger<Home2Controller> _logger;

        public Home2Controller(ILogger<Home2Controller> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            return View();
        }    
        public IActionResult Edit()
        {
            return View();
        }   
        
        [HttpPost]
        public IActionResult Edit([Bind(Prefix ="u")] User user)
        {
            return View("Edit2");
        }   

        public IActionResult Privacy()
        {
            return View();
        }    
       
        public IActionResult About()
        {
            return View();
        }

    }
}