using aCMS.Models;
using Microsoft.Framework.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aCMS.Services
{
    public class DatabaseDataService<T> : DatabaseBaseService<T> where T : ContentBase
    {
        public DatabaseDataService(IMemoryCache cache, CmsContext context)
        {
            _cache = cache;
            _context = context;
        }

        protected override IEnumerable<T> GetAll(bool html, bool cache)
        {
            IEnumerable<T> data = null;

            if (cache)
                data = _cache.Get<IEnumerable<T>>(CacheKey);

            if (data == null)
            {
                data = _context.Set<T>().ToList();
                if (html)
                    foreach (T d in data)
                        d.Content = CommonMark.CommonMarkConverter.Convert(d.Content).Trim();
                data = (from x in data orderby x.DateTimeCreated descending select x);
                if (cache)
                    _cache.Set(CacheKey, data);
            }

            return data;
        }

        protected override void RefreshCache()
        {
            IEnumerable<T> data = _context.Set<T>();
            foreach (T d in data)
                d.Content = CommonMark.CommonMarkConverter.Convert(d.Content).Trim();
            data = (from x in data orderby x.DateTimeCreated descending select x).ToList();
            _cache.Set(CacheKey, data);
        }
    }
}
