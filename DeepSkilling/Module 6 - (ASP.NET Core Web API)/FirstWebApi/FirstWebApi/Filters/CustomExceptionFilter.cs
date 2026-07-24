using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FirstWebApi.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string folder = @"C:\Temp";
            Directory.CreateDirectory(folder);

            string file = Path.Combine(folder, "ExceptionLog.txt");

            File.AppendAllText(file,
                DateTime.Now + Environment.NewLine +
                context.Exception.Message + Environment.NewLine +
                "------------------------------------" + Environment.NewLine);

            context.Result = new ObjectResult("An internal server error occurred.")
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }
    }
}