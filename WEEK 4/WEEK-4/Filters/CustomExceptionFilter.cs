using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace MyWebApi.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            File.WriteAllText("log.txt", context.Exception.ToString());
            context.Result = new ObjectResult("Internal Server Error") { StatusCode = 500 };
        }
    }
}
