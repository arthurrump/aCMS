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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using aCMS.Models;
using aCMS.Services;

namespace aCMS.Controllers
{
    public class IndexController : Controller
    {
        private IDataService<Blog> _blogService;
        private IDataService<Page> _pageService;

        public IndexController(IDataService<Blog> blogService, IDataService<Page> pageService)
        {
            _blogService = blogService;
            _pageService = pageService;
        }

        public IActionResult Index()
        {
            ContentBase data;

            try
            {
                data = _pageService.Get("/");
            }
            catch (Exception e) when (e is InvalidOperationException)
            {
                data = _blogService.Get("/");
            }

            if (data is Page)
                return View("IndexPage", data);

            if (data is Blog)
                return View("IndexBlog", data);

            return View();
        }
    }
}
