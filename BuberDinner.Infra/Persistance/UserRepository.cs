using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.App.Common.Interfaces.Persistance;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infra.Persistance
{
    public class UserRepository : IUserRepository
    {
        readonly static List<User> _users = new();
        public void Add(User user)
        {
            _users.Add(user);
        }

        public User GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(x => x.Email == email);
        }
    }
}