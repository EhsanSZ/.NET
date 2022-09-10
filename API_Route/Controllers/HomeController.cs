using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Route.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
         
        [HttpGet]
        [Route("~/Products", Order =-1)]
        public IActionResult Product()
        {
            return Ok();
        }


        [HttpGet]
        [Route("MyApi")]
        [Route("MyApi/Index")]
        [Route("MyApi/Index/{id?}")]
        [Route("[controller]/[action]")]
        [Route("api/[controller]/[action]")]
        public IActionResult Index(int id)
        {
            return Ok(id);
        }

        [HttpGet]
        [Route("book/list")]
        [Route("~/book/list")]
        public IActionResult BookList()
        {
            return Ok(true);
        }
    }
}
