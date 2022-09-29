using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Contracts;

namespace BuberDinner.App.Services.Authentication
{
    public interface IAuthenticationCommandService
    {
        AuthenticationResult Register(string firstName, string lastName, string email, string password);


    }
}