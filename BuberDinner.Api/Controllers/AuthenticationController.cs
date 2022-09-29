using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Api.Filters;
using BuberDinner.App.Authentication.Commands.Register;
using BuberDinner.App.Services.Authentication;
using BuberDinner.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    //2 option of handlng error and 1 way to applying attributes [ErrorHandlingFilterAttribute]
    public class AuthenticationController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly IAuthenticationCommandService _authenticationCommandService;
        readonly IAuthenticationQueryService _authenticationQueryService;
        public AuthenticationController(IAuthenticationCommandService authenticationService, IAuthenticationQueryService authenticationQueryService
         //IMediator mediator
         )
        {
            _authenticationCommandService = authenticationService ?? throw new ArgumentException("AAA");
            _authenticationQueryService = authenticationQueryService;
            // _mediator = mediator;
        }


        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterRequest request)
        {
            System.Console.WriteLine("in controller");

            // var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);

            var authResult = _authenticationCommandService.Register(request.FirstName, request.LastName,
            request.Email, request.Password);

            var response = new AuthenticationResponse(authResult.id, authResult.FirstName
            , authResult.LastName, authResult.Email, authResult.Token);

            return Ok(response);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationQueryService.Login(request.Email, request.Password);

            var response = new AuthenticationResponse(authResult.id, authResult.FirstName
                      , authResult.LastName, authResult.Email, authResult.Token);

            return Ok(response);
        }

    }
}