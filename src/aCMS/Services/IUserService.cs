using aCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aCMS.Services
{
    public interface IUserService
    {
        IEnumerable<User> Get();
        User Get(string username);
        User Add(string username, string password);
        User Update(User user);
        void Delete(User user);

        bool Authenticated(string httpAuthorizationHeader);
        bool Authenticated(string username, string password);
    }
}
