using aCMS.Models;
using Microsoft.AspNet.Mvc.ModelBinding;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Framework.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aCMS.Services
{
    public class DatabaseDataService<T> : IDataService<T> where T : ContentBase
    {
        private readonly IMemoryCache _cache;
        private readonly CmsContext _context;

        public DatabaseDataService(IMemoryCache cache, CmsContext context)
        {
            _cache = cache;
            _context = context;
        }

        public string CacheKey { get; } = nameof(DatabaseDataService<T>);

        public T Add(T data)
        {
            _context.Set<T>().Add(data);
            _context.SaveChanges();
            RefreshCache();

            return data;
        }

        public void Delete(T data)
        {
            _context.Set<T>().Remove(data);
            _context.SaveChanges();
            RefreshCache();

            return;
        }

        public IEnumerable<T> Get(bool html = true, bool cache = true)
        {
            return GetAll(html, cache);
        }

        public T Get(int id, bool html = true, bool cache = true)
        {
            return GetAll(html, cache).Where(x => x.Id == id).Single();
        }

        public T Update(T data)
        {
            _context.Set<T>().Update(data);
            _context.SaveChanges();
            RefreshCache();

            return data;
        }

        private IEnumerable<T> GetAll(bool html, bool cache)
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

        private void RefreshCache()
        {
            IEnumerable<T> data = _context.Set<T>();
            foreach (T d in data)
                d.Content = CommonMark.CommonMarkConverter.Convert(d.Content).Trim();
            data = (from x in data orderby x.DateTimeCreated descending select x).ToList();
            _cache.Set(CacheKey, data);
        }
    }
}
