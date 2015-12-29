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
    /// Base class for content.
    /// </summary>
    public abstract class ContentBase : IIdentifier
    {
        /// <summary>
        /// Unique identifier.
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// The url routing should use to get to this piece of content.
        /// </summary>
        [Required]
        public string Url { get; set; }
        /// <summary>
        /// The title of the content. The title should not be incorporated in the <see cref="Content"/>.
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// The subtitle or tagline.
        /// </summary>
        public string SubTitle { get; set; }
        /// <summary>
        /// The content in markdown (or html, since that is valid html too). The content should not incorporate the title, use the <see cref="Title"/> property to specify a title.
        /// </summary>
        [Required]
        public string Content { get; set; }

        /// <summary>
        /// The moment in time, relative to UTC, that the content was first created.
        /// </summary>
        [Required]
        [Editable(false, AllowInitialValue = true)]
        public DateTimeOffset DateTimeCreated { get; set; }
        /// <summary>
        /// The moment in time, relative to UTC, that the content was last updated. This field should be changed at every edit.
        /// </summary>
        [Required]
        public DateTimeOffset DateTimeUpdated { get; set; }
        /// <summary>
        /// Boolean value to indicate wether or not the <see cref="DateTimeCreated"/> and <see cref="DateTimeUpdated"/> properties should be displayed in the view.
        /// </summary>
        [Required]
        public bool DateTimeDisplay { get; set; }

        /// <summary>
        /// The id of the author of the page.
        /// </summary>
        [Required]
        public int AuthorId { get; set; }
        /// <summary>
        /// The author of the page.
        /// </summary>
        public Author Author { get; set; }
        /// <summary>
        /// Boolean value to indicate wether or not the <see cref="Author"/> property should be displayed in the view.
        /// </summary>
        [Required]
        public bool AuthorDisplay { get; set; }
    }
}
