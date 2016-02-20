using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aCMS.Models;
using aCMS.Helpers;

namespace aCMS.Services
{
    public class UserService : IUserService
    {
        UserContext _context;

        public UserService(UserContext context)
        {
            _context = context;
        }

        public IEnumerable<User> Get()
        {
            if (!_context.Users.Any())
                throw new Exception($"No users found.");

            foreach (User u in _context.Users)
                yield return u;
        }

        public User Get(string username)
        {
            IEnumerable<User> result = _context.Users.Where(user => user.Username == username);

            if (result.Count() > 1)
                throw new Exception($"More than one user with username {username}.");
            else if (result.Count() < 1)
                throw new Exception($"User {username} not found.");

            return result.SingleOrDefault();
        }

        public User Add(string username, string password)
        {
            if (_context.Users.Where(u => u.Username == username).Any())
                throw new Exception($"User {username} already exists.");

            User user = new User(username, password);
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public bool Authenticated(string httpAuthorizationHeader)
        {
            byte[] bytes = Convert.FromBase64String(httpAuthorizationHeader.Remove(0, "Basic ".Length));
            string[] creds = System.Text.Encoding.UTF8.GetString(bytes).Split(':');
            return Authenticated(creds[0], creds[1]);
        }

        public bool Authenticated(string username, string password)
        {
            User user = Get(username);
            return PasswordHelpers.VerifyHashedPassword(user.PasswordHash, user.PasswordSalt, password);
        }
    }
}
