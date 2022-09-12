using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;



namespace Routing.Bugeto.Controllers
{
    public class Home3Controller : Controller
    {
        private readonly ILogger<Home3Controller> _logger;

        public Home3Controller(ILogger<Home3Controller> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index( )
        {
            return View();
        }    
        public IActionResult Edit()
        {
            return View();
        }   
        
        [HttpPost]
        public IActionResult Edit(string[] ch, Dictionary<int,string> dic, IFormCollection keyValues , IFormFile file, IFormFileCollection formFiles )
        {
            return View();
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

    public interface IMyService
    {
        void Test();
    }
    public class MyService : IMyService
    {
        public void Test()
        {
            throw new NotImplementedException();
        }
    }
}