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
    /// Generic api controller for data.
    /// </summary>
    [Route("api/[controller]")]
    public abstract class DataApiController<T> : Controller where T : ContentBase
    {
        protected IDataService<T> _dataService { get; set; } // Get from di in implementation

        // GET: api/Ts
        [HttpGet]
        public IEnumerable<T> Get()
        {
            return _dataService.Get(html: false, cache: false);
        }

        // GET api/Ts/5
        [HttpGet("{id}")]
        public T Get(int id)
        {
            return _dataService.Get(id, html: false, cache: false);
        }

        // POST api/Ts
        [HttpPost]
        public void Post([FromBody]T data)
        {
            if (!ModelState.IsValid || data == null)
                return;

            _dataService.Add(data);
        }

        // PUT api/Ts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]T data)
        {
            if (!ModelState.IsValid || data == null || data.Id != id)
                return;

            if (_dataService.Get(id, html: false, cache: true) == null)
                return;

            _dataService.Update(data);
        }

        // DELETE api/Ts/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dataService.Delete(_dataService.Get(id, html: false, cache: true));
        }
    }
}
