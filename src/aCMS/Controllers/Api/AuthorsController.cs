using aCMS.Models;
using aCMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aCMS.Controllers.Api
{
    public class AuthorsController : DataApiController<Author>
    {
        public AuthorsController(IDataService<Author> dataService)
        {
            _dataService = dataService;
        }
    }
}
