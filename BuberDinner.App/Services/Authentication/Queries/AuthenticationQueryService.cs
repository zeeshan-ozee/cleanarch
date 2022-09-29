using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.App.Common.Interfaces.Authentication;
using BuberDinner.App.Common.Interfaces.Persistance;
using BuberDinner.Domain.Entities;

namespace BuberDinner.App.Services.Authentication
{
    public class AuthenticationQueryService : IAuthenticationQueryService
    {
        readonly IJwtTokenGenerator _jwtToeknGenerator;
        readonly IUserRepository _iUserRepo;
        public AuthenticationQueryService(IJwtTokenGenerator jwtToeknGenerator, IUserRepository iUserRepo)
        {
            _jwtToeknGenerator = jwtToeknGenerator;
            _iUserRepo = iUserRepo;
        }
        public AuthenticationResult Login(string email, string password)
        {
            //user exists
            if (_iUserRepo.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User does not exits.");
            }
            //validate password
            if (user.Password != password)
            {
                throw new Exception("incorrect password.");
            }
            //generate jwt
            var token = _jwtToeknGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);

            return new AuthenticationResult(user.Id, user.FirstName, user.LastName, email, token);
        }
    }
}