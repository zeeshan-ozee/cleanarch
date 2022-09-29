using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BuberDinner.App.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [ApiController]

    public class ErrorController : ControllerBase
    {
        [HttpGet]
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;
            var (statusCode, message) = exception switch
            {

                DuplicateEmailException => (StatusCodes.Status409Conflict, "Email already exists."),
                _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured"),

            };

            return Problem(title: message, statusCode: statusCode);
        }

    }
}