using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aCMS.Models
{
    /// <summary>
    /// Model for pages in the application.
    /// </summary>
    public class Page : ContentBase
    {
        public Page()
        {
            DateTimeDisplay = false;
            AuthorDisplay = false;
        }
    }
}
