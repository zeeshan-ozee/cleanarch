using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BuberDinner.Api.Middleware
{
    // public static class NameMiddlewareExt
    // {
    //     public static void UseName(this IApplicationBuilder app)
    //     {
    //         app.UseMiddleware<NameMiddleware>();
    //     }
    // }

    public class ErrorHandlingMiddleware
    {

        private readonly RequestDelegate _next;


        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (System.Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }

        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            System.Console.WriteLine("Exception handled by middleware");
            var code = HttpStatusCode.InternalServerError;
            var result = JsonConvert.SerializeObject(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}