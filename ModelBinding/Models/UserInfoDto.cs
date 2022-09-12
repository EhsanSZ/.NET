using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelBinding.Models
{
    public class UserInfoDto
    {
        [BindNever]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
 
        public string Token { get; set; }
    }   
    
    public class UserInfoClientDto
    {
      
        public string Name { get; set; }
        public string LastName { get; set; }

        [FromHeader]
        public string Token { get; set; }
    }
}
