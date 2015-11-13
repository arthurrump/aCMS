using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aCMS.Services
{
    public interface IDataService<T>
    {
        string CacheKey { get; }

        IEnumerable<T> Get(bool html = true, bool cache = true);
        T Get(int id, bool html = true, bool cache = true);
        T Add(T data);
        T Update(T data);
        void Delete(T data);
    }
}
