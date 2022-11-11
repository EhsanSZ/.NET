using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    [Authorize(Roles = "Admin,Operator")]
    //[Authorize(Roles = "")]
    public class AuthorizeTestController : Controller
    {
     
        public string Index()
        {
            return "Index";
        }  
        
        [Authorize(Roles = "Operator")]
        public string Edit()
        {
            return "Index";
        }
    }
}
