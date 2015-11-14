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
    public class PagesController : DataApiController<Page>
    {
        public PagesController(IDataService<Page> dataService)
        {
            _dataService = dataService;
        }
    }
}
