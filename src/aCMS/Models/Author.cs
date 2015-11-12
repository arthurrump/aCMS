using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aCMS.Models
{
    /// <summary>
    /// Model for authors in the application. Might also be used for authentication in the future.
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Unique identifier for an author.
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// The name of the author.
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Picture of the author (gravatar eg).
        /// </summary>
        [Required]
        public string ImageUrl { get; set; }
        /// <summary>
        /// Little biography about the author. Written in Markdown.
        /// </summary>
        [Required]
        public string Bio { get; set; }

        /// <summary>
        /// Twitter handle of the author, without the @-sign.
        /// </summary>
        public string TwitterHandle { get; set; }
        /// <summary>
        /// Facebook username of the author.
        /// </summary>
        public string FacebookUsername { get; set; }
        /// <summary>
        /// Github username of the author, without the @-sign.
        /// </summary>
        public string GithubUsername { get; set; }
        /// <summary>
        /// BitBucket username of the author.
        /// </summary>
        public string BitbucketUsername { get; set; }
        /// <summary>
        /// StackOverflow username of the author.
        /// </summary>
        public string StackoverflowUsername { get; set; }
        /// <summary>
        /// Codepen username of the author.
        /// </summary>
        public string CodepenUsername { get; set; }
        /// <summary>
        /// Email-adress of the author. Toggle public display by <see cref="EmailPublicDisplay"/>.
        /// </summary>
        [EmailAddress]
        public string Email { get; set; }
        /// <summary>
        /// Toggle wether author's <see cref="Email"/> is public available. Default to false.
        /// </summary>
        public bool EmailPublicDisplay { get; set; } = false;

        /// <summary>
        /// A list of pages the author has written. <seealso cref="Page"/>
        /// </summary>
        public List<Page> Pages { get; set; }
    }
}
