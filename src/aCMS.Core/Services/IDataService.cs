//     Copyright 2016 Arthur Rump
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

using aCMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aCMS.Core.Services
{
    public interface IDataService<T> where T : IIdentifier
    {
        IEnumerable<T> Get(int count, int page = 0, bool html = true);
        T Get(int id, bool html = true);
        T Get(string url, bool html = true);
        T Add(T data);
        T Update(T data);
        void Delete(T data);
    }
}
