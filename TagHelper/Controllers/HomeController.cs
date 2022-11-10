using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TagHelper.Models;

namespace TagHelper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [Route("Home/Index", Name = "indexRoute")]
        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            var TehranGroup = new SelectListGroup { Name = "تیم های تهرانی" };
            var otherGroup = new SelectListGroup { Name = "تیم های شهرستان" };

            TeamViewModel model = new TeamViewModel()
            {
                Teams = new List<SelectListItem>()
                 {
                      new SelectListItem { Value ="1" , Text = "پرسپولیس"},
                      new SelectListItem { Value ="2" , Text = "سپاهان"},
                      new SelectListItem { Value ="3" , Text = "تراکتورسازی"},
                      new SelectListItem { Value ="4" , Text = "سایپا"},
                      new SelectListItem { Value ="5" , Text = "استقلال"},
                 },
                TeamOptionGroup = new List<SelectListItem>()
                {
                     new SelectListItem  {  Group=TehranGroup, Value ="1" , Text = "پرسپولیس"},
                      new SelectListItem {Group=otherGroup, Value ="2" , Text = "سپاهان"},
                      new SelectListItem {Group=otherGroup, Value ="3" , Text = "تراکتورسازی"},
                      new SelectListItem { Group=TehranGroup,Value ="4" , Text = "سایپا"},
                      new SelectListItem { Group=TehranGroup,Value ="5" , Text = "استقلال"},
                },
                TeamMltipleItem = new List<SelectListItem>()
                {
                      new SelectListItem { Value ="1" , Text = "پرسپولیس"},
                      new SelectListItem { Value ="2" , Text = "سپاهان"},
                      new SelectListItem { Value ="3" , Text = "تراکتورسازی"},
                      new SelectListItem { Value ="4" , Text = "سایپا"},
                      new SelectListItem { Value ="5" , Text = "استقلال"},
                }
            };
            //model.Team = "4";
            model.TeamOptionGroup.Insert(0, new SelectListItem { Value = "", Text = "None" });
            return View(model);
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
