using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace StateNumbersAPI.MiddleWares
{
   public class GlobalExceptionhandlingMiddleWare : IMiddleware
   {
      private readonly ILogger logger;

      public GlobalExceptionhandlingMiddleWare(ILogger<GlobalExceptionhandlingMiddleWare> logger) =>
      
         this.logger = logger;
      

      public async Task InvokeAsync(HttpContext context, RequestDelegate next)
      {
         try
         {
            await next(context);
         }
         catch (Exception e)
         {
            logger.LogError(e, e.Message);

            context.Response.StatusCode =
               (int)HttpStatusCode.InternalServerError;
            context.Response.StatusCode =
               (int)HttpStatusCode.BadRequest;

            ProblemDetails problem = new();
            if (context.Response.StatusCode== (int)HttpStatusCode.BadRequest )
            {
               problem.Status = (int)HttpStatusCode.BadRequest;
               problem.Type = e.Message;
               problem.Detail = "the server cannot process";
            }
            else if(context.Response.StatusCode == (int)HttpStatusCode.InternalServerError)
            {
               problem.Status = (int)HttpStatusCode.InternalServerError;
               problem.Type = e.Message;
               problem.Detail = "the internal server error has occured";
            }
            string json = JsonSerializer.Serialize(problem);
            await context.Response.WriteAsync(json);
            context.Response.ContentType = "application/json";


         }
      }
   }
}
