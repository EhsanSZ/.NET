using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelBinding.Models;

namespace Routing.Bugeto.Controllers
{
    public class Home1Controller : Controller
    {
        private readonly ILogger<Home1Controller> _logger;

        public Home1Controller(ILogger<Home1Controller> logger)
        {
            _logger = logger;
        }
     
        //public IActionResult Index(int id ,[FromQuery(Name ="personName")]string FullName)
        //{
        //    return View();
        //}     
        
        public IActionResult Index( )
        {
            return View();
        }   
        
        [HttpPost]
        public IActionResult Edit(/*[Bind("LastName","Name","Token")]*/UserInfoDto user)
        {
            user.UserId = 20;
            EditUserService editUser = new EditUserService();
            editUser.Execute(user);
            //------
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
 
}


public class EditUserService
{
    public void Execute(UserInfoDto user)
    {
        //Edit
    }
}