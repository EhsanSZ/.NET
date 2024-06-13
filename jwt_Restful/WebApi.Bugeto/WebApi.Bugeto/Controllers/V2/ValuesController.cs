using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Bugeto.Controllers.V2
{
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ValuesController : V1.ValuesController
    {
     
        public override IEnumerable<string> Get()
        {
            return new string[] { "V2 value1", "V2 value2" ,"V2 value3" };
        }
    }
}
