using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters.Models.Filters
{
    public class ShowMessage : Attribute, IResultFilter
    {

        private readonly string _source;
        private readonly ILogger _logger;
        public ShowMessage(string source, ILogger logger)
        {
            _source = source;
            _logger = logger;
        }
        public void OnResultExecuting(ResultExecutingContext context)
        {
            PrintMessage(context, $"{_source} Executing");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            PrintMessage(context, $"{_source}  -> Execute");

        }



        private void PrintMessage(FilterContext context, string message)
        {
            byte[] bytes = Encoding.ASCII.GetBytes($"<div> <h1>  {message} </h1> </div>");
            context.HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
        }
    }
}
