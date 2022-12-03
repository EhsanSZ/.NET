using Application.FacadePattern;
using Facade_In_Asp.Net_Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Facade_In_Asp.Net_Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFacadeService _facadeService;
        public HomeController(IFacadeService facadeService)
        {
            _facadeService = facadeService;
        }

        public IActionResult Index()
        {
            _facadeService.RegisterUserService.Execute();
            _facadeService.LoginUserService.Execute();
            return View();
        }

    }
}
