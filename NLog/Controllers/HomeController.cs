using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NLog.Controllers
{
    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public override string ToString()
        {
            return $"{Name}  {LastName}";
        }
    }

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogTrace("this is a LogTrace log");
            _logger.LogDebug("this is a LogDebug log");
            _logger.LogInformation("this is a LogInformation log");
            _logger.LogWarning("this is a LogWarning log");
            _logger.LogError("this is a LogError log");
            _logger.LogCritical("this is a LogCritical log");
            return View();
        }

        public IActionResult Database()
        {

            _logger.LogInformation("This Log Save In Database SQLServer");
            return View();
        }

        public IActionResult Json()
        {

            Person person = new Person()
            {
                Name = "Ehsan",
                LastName = "Seyedzadeh",
                PhoneNumber = "123456789",
            };
            //add To DataBase
            //Save

            _logger.LogInformation("New Prsern {Person}", person);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
