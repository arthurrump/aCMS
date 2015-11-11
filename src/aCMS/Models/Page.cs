using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aCMS.Models
{
    public class Page
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; } // Markdown

        [Required]
        public DateTimeOffset DateTimeCreated { get; set; }
        [Required]
        public DateTimeOffset DateTimeUpdated { get; set; }
        [Required]
        public bool DateTimeDisplay { get; set; } = false;

        [Required]
        public string Author { get; set; }
        [Required]
        public bool AuthorDisplay { get; set; } = false;
    }
}
