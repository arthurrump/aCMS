using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aCMS.Models
{
    public class Blog : ContentBase
    {
        public Blog()
        {
            AuthorDisplay = false;
            DateTimeDisplay = false;
        }

        List<Post> Posts { get; set; }
    }
}
