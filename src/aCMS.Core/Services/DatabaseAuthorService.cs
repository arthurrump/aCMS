using aCMS.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aCMS.Core.Services
{
    public class DatabaseAuthorService : IDataService<Author>
    {
        CmsContext _context;

        public DatabaseAuthorService(CmsContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> Get(bool html = true)
        {
            foreach (Author a in _context.Set<Author>().OrderBy(x => x.Name))
                yield return a;
        }

        public Author Get(string url, bool html = true)
        {
            return _context.Set<Author>().Where(x => x.Url == url).Single();
        }

        public Author Get(int id, bool html = true)
        {
            return _context.Set<Author>().Where(x => x.Id == id).Single();
        }

        public Author Add(Author data)
        {
            _context.Set<Author>().Add(data);
            _context.SaveChanges();

            return data;
        }

        public Author Update(Author data)
        {
            _context.Set<Author>().Update(data);
            _context.SaveChanges();

            return data;
        }

        public void Delete(Author data)
        {
            _context.Set<Author>().Remove(data);
            _context.SaveChanges();

            return;
        }
    }
}
