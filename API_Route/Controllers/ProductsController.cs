using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace API_Route.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        [HttpGet]
        [Route("~/Products" , Name ="productList" , Order =-2 )]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}


