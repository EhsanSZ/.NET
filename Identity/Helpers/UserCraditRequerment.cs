using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Helpers
{
    public class UserCreditRequerment : IAuthorizationRequirement
    {
        public int Credit { get; set; }
        public UserCreditRequerment(int credit)
        {
            Credit = credit;
        }

    }

    public class UserCreditHandler : AuthorizationHandler<UserCreditRequerment>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext
         context, UserCreditRequerment requirement)
        {
            var claim= context.User.FindFirst("Cradit");
            if(claim !=null)
            {
                //در اینجا میتوینم دیتا از دیتا بیس بگیریم مثلا سن کاربر رو بررسی کنیم
                int cradit = int.Parse(claim?.Value);
                if(cradit >= requirement.Credit)
                {
                    context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }
    }
}
