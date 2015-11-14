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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aCMS.Models
{
    /// <summary>
    /// Model for authors in the application. Might also be used for authentication in the future.
    /// </summary>
    public class Author : IIdentifier
    {
        /// <summary>
        /// Unique identifier for an author.
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// The url for the author page.
        /// </summary>
        [Required]
        public string Url { get; set; }
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
