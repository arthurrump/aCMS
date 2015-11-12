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
    public class Page
    {
        /// <summary>
        /// Unique identifier for every page.
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// The url routing should use to get to this page.
        /// </summary>
        [Required]
        public string Url { get; set; }
        /// <summary>
        /// The title of the page. The title should not be incorporated in the content.
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// The content of the page in markdown (or html, since that is valid html too). The content should not incorporate the title, use the <see cref="Title"/> property to specify a title.
        /// </summary>
        [Required]
        public string Content { get; set; }

        /// <summary>
        /// The moment in time, relative to UTC, that the page was first created. This field is automatically assigned when creating an instance of Page and should not be changed.
        /// </summary>
        [Required]
        [Editable(false, AllowInitialValue = true)]
        public DateTimeOffset DateTimeCreated { get; set; } = DateTimeOffset.Now;
        /// <summary>
        /// The moment in time, relative to UTC, that the page was last updated. This field should be changed at every edit.
        /// </summary>
        [Required]
        public DateTimeOffset DateTimeUpdated { get; set; }
        /// <summary>
        /// Boolean value to indicate wether or not the <see cref="DateTimeCreated"/> and <see cref="DateTimeUpdated"/> properties should be displayed in the view.
        /// </summary>
        [Required]
        public bool DateTimeDisplay { get; set; } = false;

        /// <summary>
        /// The id of the author of the page.
        /// </summary>
        [Required]
        public int AuthorId { get; set; }
        /// <summary>
        /// The author of the page.
        /// </summary>
        [Required]
        public Author Author { get; set; }
        /// <summary>
        /// Boolean value to indicate wether or not the <see cref="Author"/> property should be displayed in the view.
        /// </summary>
        [Required]
        public bool AuthorDisplay { get; set; } = false;
    }
}
