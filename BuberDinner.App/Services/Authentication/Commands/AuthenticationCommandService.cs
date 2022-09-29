using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.App.Common.Interfaces.Authentication;
using BuberDinner.App.Common.Interfaces.Persistance;
using BuberDinner.Domain.Entities;

namespace BuberDinner.App.Services.Authentication
{
    public class AuthenticationCommandService : IAuthenticationCommandService
    {
        readonly IJwtTokenGenerator _jwtToeknGenerator;
        readonly IUserRepository _iUserRepo;
        public AuthenticationCommandService(IJwtTokenGenerator jwtToeknGenerator, IUserRepository iUserRepo)
        {
            _jwtToeknGenerator = jwtToeknGenerator;
            _iUserRepo = iUserRepo;
        }
        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            System.Console.WriteLine("in register method");
            //check if user does not exists
            if (_iUserRepo.GetUserByEmail(email) is not null)
            {
                throw new Exception("User exists.");
            }

            var user = new User
            {

                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Password = password
            };
            //create user (generate unqiue Id)
            _iUserRepo.Add(user);


            //create token
            //Guid userId = Guid.NewGuid();

            var token = _jwtToeknGenerator.GenerateToken(user.Id, firstName, lastName);

            return new AuthenticationResult(user.Id, firstName, lastName, email, token);
        }

    }
}