using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuberDinner.Contracts
{

    public record AuthenticationResponse(
        Guid id,
       string FirstName,
       string LastName,
       string Email,
       string Token

   );
}