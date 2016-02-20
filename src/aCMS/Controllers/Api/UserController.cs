using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using aCMS.Models;
using aCMS.Services;
using System.Diagnostics.Contracts;
using System.Net;
using System.IO;
using Microsoft.AspNet.Http;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace aCMS.Controllers.Api
{
    public class UserController : Controller
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("all")]
        public ActionResult Get()
        {
            if (!_userService.Authenticated(Request.Headers["Authorization"]))
                return new HttpUnauthorizedResult();

            IEnumerable<User> users = null;

            try
            {
                users = _userService.Get();
            }
            catch (Exception)
            {
                var resp = new ContentResult();
                resp.StatusCode = 500;
                resp.Content = "HTTP 500: An error occurred on the server.";
                return resp;
            }

            return Json(users);
        }

        [HttpGet("{username}")]
        public ActionResult Get(string username)
        {
            if (!_userService.Authenticated(Request.Headers["Authorization"]))
                return new HttpUnauthorizedResult();

            return Ok(_userService.Get(username));
        }

        [HttpPost]
        public void Post([FromBody]UsernamePasswordPair data)
        {
            if (!_userService.Authenticated(Request.Headers["Authorization"]))
                return;

            _userService.Add(data.Username, data.Password);
        }

        [HttpPut("{username}")]
        public void Put(string username, [FromBody]User user)
        {
            if (!_userService.Authenticated(Request.Headers["Authorization"]))
                return;

            if (!ModelState.IsValid || user == null || user.Username != username)
                return;

            if (_userService.Get(username) == null)
                return;

            _userService.Update(user);
        }

        [HttpPut("{username}/password")]
        public void Put(string username, [FromBody]UsernamePasswordPair data)
        {
            if (!_userService.Authenticated(Request.Headers["Authorization"]))
                return;

            if (username != data.Username || _userService.Get(username) == null)
                return;

            User user = _userService.Get(username);
            user.UpdatePassword(data.Password);
            _userService.Update(user);
        }

        [HttpDelete("{username}")]
        public void Delete(string username)
        {
            if (!_userService.Authenticated(Request.Headers["Authorization"]))
                return;

            if (_userService.Get().Count() <= 1)
                return;

            _userService.Delete(_userService.Get(username));
        }
    }
}
