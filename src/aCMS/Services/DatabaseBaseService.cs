//     Copyright 2015 Arthur Rump
//  
//     Licensed under the Apache License, Version 2.0 (the "License");
//     you may not use this file except in compliance with the License.
//     You may obtain a copy of the License at
//  
//         http://www.apache.org/licenses/LICENSE-2.0
//  
//     Unless required by applicable law or agreed to in writing, software
//     distributed under the License is distributed on an "AS IS" BASIS,
//     WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//     See the License for the specific language governing permissions and
//     limitations under the License.

using aCMS.Models;
using Microsoft.AspNet.Mvc.ModelBinding;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aCMS.Services
{
    public abstract class DatabaseBaseService<T> : IDataService<T> where T : class, IIdentifier
    {
        protected IMemoryCache _cache; // Get from di in implementation
        protected CmsContext _context; // Get from di in implementation

        public string CacheKey { get; } = $"{nameof(DatabaseBaseService<T>)}<{typeof(T)}>";

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

        public T Get(string url, bool html = true, bool cache = true)
        {
            return GetAll(html, cache).Where(x => x.Url == url).Single();
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

        protected abstract IEnumerable<T> GetAll(bool html, bool cache);

        protected abstract void RefreshCache();
    }
}
