using aCMS.Models;
using Microsoft.Framework.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aCMS.Services
{
    public class DatabaseAuthorService : DatabaseBaseService<Author>
    {
        public DatabaseAuthorService(IMemoryCache cache, CmsContext context)
        {
            _cache = cache;
            _context = context;
        }

        protected override IEnumerable<Author> GetAll(bool html, bool cache)
        {
            IEnumerable<Author> data = null;

            if (cache)
                data = _cache.Get<IEnumerable<Author>>(CacheKey);

            if (data == null)
            {
                data = _context.Set<Author>().ToList();

                if (cache)
                    _cache.Set(CacheKey, data);
            }

            return data;
        }

        protected override void RefreshCache()
        {
            _cache.Set(CacheKey, _context.Set<Author>().ToList());            
        }
    }
}
