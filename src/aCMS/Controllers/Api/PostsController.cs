using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using aCMS.Models;
using aCMS.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace aCMS.Controllers.Api
{
    public class PostsController : DataApiController<Post>
    {
        public PostsController(IDataService<Post> dataService)
        {
            _dataService = dataService;
        }
    }
}
