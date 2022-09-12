using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Bugeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Edit(UserInfoDto user)
        {
            user.UserId = 20;
            EditUserService editUser = new EditUserService();
            editUser.Execute(user);
            //------
            return Ok();
        }
    }
}
