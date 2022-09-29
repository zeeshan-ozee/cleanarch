using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuberDinner.App.Authentication.Commands.Register
{
    public record RegisterCommand
   (

       string FirstName,
       string LastName,
       string Email,
       string Password
   );

}