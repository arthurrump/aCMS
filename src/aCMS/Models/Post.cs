using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aCMS.Models
{
    public class Post : ContentBase
    {
        public Post()
        {
            AuthorDisplay = true;
            DateTimeDisplay = true;
        }

        /// <summary>
        /// Id of the blog this post belongs to.
        /// </summary>
        [Required]
        public int BlogId { get; set; }
        /// <summary>
        /// The blog this post belongs to.
        /// </summary>
        public Blog Blog { get; set; }
    }
}
