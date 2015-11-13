using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using aCMS.Services;
using Microsoft.Framework.Caching.Memory;
using aCMS.Models;

namespace aCMS.Controllers.Api
{
    /// <summary>
    /// Api controller for blogs.
    /// </summary>
    [Route("api/[controller]")]
    public class BlogsController : Controller
    {
        IDataService<Blog> _blogService;

        public BlogsController(IDataService<Blog> blogService)
        {
            _blogService = blogService;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Blog> Get()
        {
            return _blogService.Get(html: false, cache: false);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Blog Get(int id)
        {
            return _blogService.Get(id, html: false, cache: false);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Blog data)
        {
            if (!ModelState.IsValid || data == null)
                return;

            _blogService.Add(data);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Blog data)
        {
            if (!ModelState.IsValid || data == null || data.Id != id)
                return;

            if (_blogService.Get(id, html: false, cache: true) == null)
                return;

            _blogService.Update(data);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _blogService.Delete(_blogService.Get(id, html: false, cache: true));
        }
    }
}
