using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Models.Filters
{
    public class ValidateModelAttribute :Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {

            var param = context.ActionArguments.SingleOrDefault();
            if(param.Value == null)
            {
                context.Result = new BadRequestObjectResult("Model is Null");
            }

            if(!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
             ;
        }


    }
}
