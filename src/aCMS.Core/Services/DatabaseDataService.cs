using aCMS.Core.Models;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aCMS.Core.Services
{
    public class DatabaseDataService<T> : IDataService<T> where T : ContentBase
    {
        protected CmsContext _context;

        public DatabaseDataService(CmsContext context)
        {
            _context = context;
        }

        public IEnumerable<T> Get(int count, int page = 0, bool html = true)
        {
            IEnumerable<T> data = _context.Set<T>().OrderBy(x => x.DateTimeUpdated);
            for (int i = 0; i < count && i + page * count < data.Count(); i++)
            {
                if (html)
                    data.ElementAt(i).Content = CommonMark.CommonMarkConverter.Convert(data.ElementAt(i).Content).Trim();

                yield return data.ElementAt(i);
            }
        }

        public T Get(string url, bool html = true)
        {
            T data = _context.Set<T>().Where(x => x.Url == url).Single();
            if (html)
                data.Content = CommonMark.CommonMarkConverter.Convert(data.Content).Trim();

            return data;
        }

        public T Get(int id, bool html = true)
        {
            T data = _context.Set<T>().Where(x => x.Id == id).Single();
            if (html)
                data.Content = CommonMark.CommonMarkConverter.Convert(data.Content).Trim();

            return data;
        }

        public T Add(T data)
        {
            _context.Set<T>().Add(data);
            _context.SaveChanges();

            return data;
        }

        public T Update(T data)
        {
            _context.Set<T>().Update(data);
            _context.SaveChanges();

            return data;
        }

        public void Delete(T data)
        {
            _context.Set<T>().Remove(data);
            _context.SaveChanges();

            return;
        }
    }
}
